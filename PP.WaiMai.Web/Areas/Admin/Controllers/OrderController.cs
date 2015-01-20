using Newtonsoft.Json;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Admin/Order/
        /// <summary>
        /// 审核订单：所有下单成功的订单，转为交易成功
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckOrder(string beginTime, string endTime, string userName)
        {
            try
            {
                if (!OperateHelper.IsLogin())
                {
                    return JsonMsgNoOk("对不起，你没权限操作");
                }
                if (!OperateHelper.User.IsAdmin)
                {
                    return JsonMsgNoOk("对不起，你没权限操作");
                }

                var modelOrder = BLLSession.IOrderService.GetListBy(m => true).OrderByDescending(m => m.OrderID).ToList();
                if (!string.IsNullOrEmpty(beginTime))
                {
                    DateTime beginTime1 = DateTime.Parse(beginTime);
                    modelOrder = modelOrder.Where(m => m.CreateDate >= beginTime1).ToList();
                }
                if (!string.IsNullOrEmpty(endTime))
                {
                    DateTime endTime1 = DateTime.Parse(endTime);
                    modelOrder = modelOrder.Where(m => m.CreateDate <= endTime1).ToList();
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    modelOrder = modelOrder.Where(m => m.User.UserName.Contains(userName)).ToList();
                }

                var model = BLLSession.IOrderService.ModifyBy(new Order() { OrderStatus = (int)OrderStatusEnum.Succeed }
                    , m => m.OrderStatus == (int)OrderStatusEnum.Handle, new string[] { "OrderStatus" });
                return JsonMsgOk();
            }
            catch (Exception ex)
            {
                return JsonMsgErr(ex.Message);
            }
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
                if (!OperateHelper.IsLogin())
                {
                    return JsonMsgNoOk("对不起，请先登陆");
                }
                var isSucceed = BLLSession.IOrderService.OrderCancel(id);
                if (isSucceed)
                {
                    return JsonMsgOk("取消成功", "/Admin/Restaurant");
                }
                return JsonMsgNoOk("取消失败，请确定该订单是否已经审核");
            }
            catch (Exception ex)
            {
                return JsonMsgNoOk(ex.Message);
            }
        }

    }
}