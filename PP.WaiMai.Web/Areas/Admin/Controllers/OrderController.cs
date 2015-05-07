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
                //当前只是在内存里过滤，修改的朋友，可以改为按条件过滤
                var modelOrder = BLLSession.IOrderService.GetListBy(m => true).ToList();
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
                var orderIdList = modelOrder.Select(m => m.OrderID).ToList();

                var model = BLLSession.IOrderService.ModifyBy(new Order() { OrderStatus = (int)OrderStatusEnum.Succeed }
                    , m => m.OrderStatus == (int)OrderStatusEnum.Handle && orderIdList.Contains(m.OrderID)
                    , new string[] { "OrderStatus" });

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
                return JsonMsgNoOk("取消失败，该订单状态已变更，请刷新页面重试");
            }
            catch (Exception ex)
            {
                return JsonMsgNoOk(ex.Message);
            }
        }

    }
}