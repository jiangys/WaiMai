using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
        public ActionResult Expend(int? page)
        {
            if (!OperateHelper.IsLogin())
            {
                return View();
            }
            var orderList = BLLSession.IOrderService.GetListBy(m => m.UserID == CurrentUser.UserID);
            var rechargeList = BLLSession.IRechargeService.GetListBy(m => m.UserID == CurrentUser.UserID && !m.IsDel);
            //两个List合成一个List
            List<ExpendViewModel> list = new List<ExpendViewModel>();
            foreach (var item in orderList)
            {
                list.Add(new ExpendViewModel()
                {
                    CreateDate = item.CreateDate,
                    ConsumeAmount = item.TotalPrice,
                    RechargeAmount = 0,
                    Description = "订餐完成消耗金额（订单号：" + item.OrderID + ")"
                });
            }
            foreach (var item in rechargeList)
            {
                list.Add(new ExpendViewModel()
                {
                    CreateDate = item.CreateDate,
                    ConsumeAmount = 0,
                    RechargeAmount = item.RechargeAmount,
                    Description = "充值完成增加金额（充值号：" + item.RechargeID + ") "
                });
            }
            return View(list.OrderByDescending(m => m.CreateDate).ToPagedList(page ?? 1, 15));
        }
    }
}