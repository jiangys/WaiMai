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
        public ActionResult ExpendLog(int? page)
        {
            if (!OperateHelper.IsLogin())
            {
                return View();
            }
            var model = BLLSession.IExpendLogService.GetListBy(m => m.UserID==CurrentUser.UserID).OrderByDescending(m => m.ExpendLogID);
            //剩余总金额
            ViewBag.RemainAmount = model.Sum(m => m.RechargeAmount) - model.Sum(m => m.ConsumeAmount);
            return View(model.ToPagedList(page ?? 1, 15));
        }
    }
}