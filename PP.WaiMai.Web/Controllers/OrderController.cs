using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model;
using Newtonsoft.Json;
using PP.WaiMai.Model.ViewModels;
using System.Transactions;

namespace PP.WaiMai.Web.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        /// <summary>
        /// 今日订单显示
        /// </summary>
        /// <param name="id">餐厅ID，如果有值，则显示界面指定显示相应的Tab标签页</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            var doModeType = BLLSession.IConfigService.GetModel(m => m.ConfigName == "DoModeType");
            if (doModeType != null && !string.IsNullOrEmpty(doModeType.ConfigValue))
            {
                var doModeTypeValue = JsonConvert.DeserializeObject<ConfigDoModeTypeViewModel>(doModeType.ConfigValue);
                if (doModeTypeValue.DoTime.ToShortDateString() == DateTime.Now.ToShortDateString() && !doModeTypeValue.IsDayMode)
                {
                    var list = BLLSession.IOrderService.GetListBy(m => m.CreateDate > doModeTypeValue.DoTime && m.CreateDate < DateTime.Now);
                    ViewBag.IsDayMode = false;
                    return View(list);
                }
            }
            ViewBag.IsDayMode = true;
            var startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //得到所有的订单列表
            var orderList = BLLSession.IOrderService.GetListBy(m => m.CreateDate > startDate && m.CreateDate < DateTime.Now);
            //返回餐厅集合
            ViewBag.RestaurantList = BLLSession.IRestaurantService.GetListBy(m => m.IsEnable).Take(2).ToList().Select(m => m.ToPOCO()).ToList();
            //显示相应的Tab标签页
            ViewBag.ShowTabId = id;
            return View(orderList);
        }
        [HttpPost]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //开启事务,保证数据的一致性
                    using (var scope = new TransactionScope())
                    {
                        if (!OperateHelper.IsLogin())
                        {
                            return JsonMsgNoOk("请先登陆");
                        }
                        var userModel = BLLSession.IUserService.GetModel(m => m.UserID == OperateHelper.User.UserID);

                        if (userModel.Amount < model.TotalPrice)
                        {
                            return JsonMsgNoOk("当前余额为"+userModel.Amount+"元，余额不足，请先充值");
                        }

                        model.UserID = OperateHelper.User.UserID;
                        model.TotalCount = 1;
                        model.CreateDate = DateTime.Now;
                        model.IsDel = false;
                        model.Version = 1;
                        var result = BLLSession.IOrderService.Add(model);
                        //更新用户剩余金额
                        userModel.Amount = userModel.Amount - model.TotalPrice;
                        BLLSession.IUserService.ModifyModel(userModel);
                        scope.Complete();//提交事务
                    }
                    return JsonMsgOk("下单成功", "/Order/Index");
                }
                catch (Exception ex)
                {
                    return JsonMsgNoOk(ex.Message);
                }

            }
            return JsonMsgNoOk("下单失败");
        }
    }
}