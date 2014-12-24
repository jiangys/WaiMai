using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Transactions;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        /// <summary>
        /// 我的消费
        /// </summary>
        /// <returns></returns>
        public ActionResult ExpendLog(int? page)
        {
            if (!OperateHelper.IsLogin())
            {
                return View();
            }
            var model = BLLSession.IExpendLogService.GetListBy(m => m.UserID == CurrentUser.UserID).OrderByDescending(m => m.ExpendLogID);
            //剩余总金额
            ViewBag.RemainAmount = model.Sum(m => m.RechargeAmount) - model.Sum(m => m.ConsumeAmount);
            return View(model.ToPagedList(page ?? 1, 15));
        }

        /// <summary>
        /// 我的订单
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MyOrder(int? page)
        {
            if (!OperateHelper.IsLogin())
            {
                return View();
            }
            var model = BLLSession.IOrderService.GetListBy(m => m.UserID == CurrentUser.UserID).OrderByDescending(m => m.OrderID).ToList();
            return View(model.ToPagedList(page ?? 1, 15));
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OrderCancel(int id)
        {
            try
            {
                //开启事务,保证数据的一致性
                using (var scope = new TransactionScope())
                {
                    var orderModel = BLLSession.IOrderService.GetModel(m => m.OrderID == id);
                    //插入数据到消费流水表
                    BLLSession.IExpendLogService.Add(new ExpendLog()
                    {
                        UserID = CurrentUser.UserID,
                        ConsumeAmount = -orderModel.TotalPrice,
                        RechargeAmount = 0,
                        CreateDate = DateTime.Now,
                        ExpendLogTypeID = id,
                        ExpendLogType = (int)ExpendLogTypeEnum.Order,
                        Description = "取消订餐退款金额"
                    });
                    //更新用户剩余金额
                    var userModel = BLLSession.IUserService.GetModel(m => m.UserID == orderModel.UserID);
                    userModel.Amount = userModel.Amount + orderModel.TotalPrice;
                    BLLSession.IUserService.ModifyModel(userModel);
                    //删除订单
                    orderModel.IsDel = true;
                    BLLSession.IOrderService.ModifyModel(orderModel);

                    scope.Complete();//提交事务 
                }
                return JsonMsgOk("取消成功", "/Admin/Restaurant");
            }
            catch (Exception ex)
            {
                return JsonMsgNoOk(ex.Message);
            }
        }


    }
}