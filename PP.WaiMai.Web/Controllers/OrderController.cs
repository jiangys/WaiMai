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
using PP.WaiMai.Model.Enums;

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
            DateTime currDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //得到所有的订单列表
            var orderList = BLLSession.IOrderService.GetListBy(m => m.OrderStatus == (int)OrderStatusEnum.Handle && m.CreateDate > currDate);
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
                    var isDo = true;
                    var doOrderValue = BLLSession.IConfigService.GetModel(m => m.ConfigName == "DoOrder").ConfigValue;
                    if (doOrderValue != null)
                    {
                        var doOrderModel = JsonConvert.DeserializeObject<ConfigDoOrderViewModel>(doOrderValue);
                        if (doOrderModel.DoTime == DateTime.Now.ToShortDateString())
                        {
                            isDo = doOrderModel.IsDo;
                        }
                    }
                    if (!isDo)
                    {
                        return JsonMsgNoOk("订餐已停止，系统关闭中");
                    }

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
                            return JsonMsgNoOk("当前余额为" + userModel.Amount + "元，余额不足，请先充值");
                        }
                        //插入数据到订单
                        model.UserID = OperateHelper.User.UserID;
                        model.TotalCount = 1;
                        model.CreateDate = DateTime.Now;
                        model.IsDel = false;
                        model.Version = 1;
                        var result = BLLSession.IOrderService.Add(model);
                        //更新用户剩余金额
                        userModel.Amount = userModel.Amount - model.TotalPrice;
                        BLLSession.IUserService.ModifyModel(userModel);
                        //插入数据到消费流水表
                        BLLSession.IExpendLogService.Add(new ExpendLog()
                        {
                            UserID = CurrentUser.UserID,
                            ConsumeAmount = model.TotalPrice,
                            RechargeAmount = 0,
                            CreateDate = DateTime.Now,
                            ExpendLogTypeID = model.OrderID,
                            ExpendLogType = (int)ExpendLogTypeEnum.Order,
                            Description = "订餐完成消耗金额"
                        });
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