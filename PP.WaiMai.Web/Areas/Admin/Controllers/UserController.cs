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
        /// 修改个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateUserInfo()
        {
            if (!OperateHelper.IsLogin())
            {
                return View();
            }

            var userInfo = BLLSession.IUserService.GetListBy(m => m.UserID == CurrentUser.UserID).FirstOrDefault();
            UpdateUserInfoModel model = new UpdateUserInfoModel();
            model.UserName = userInfo.UserName;
            model.DepartmentType = userInfo.DepartmentType;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUserInfo(UpdateUserInfoModel model)
        {
            var userInfo = BLLSession.IUserService.GetModel(m => m.UserID == CurrentUser.UserID);
            userInfo.UserName = model.UserName;
            userInfo.DepartmentType = model.DepartmentType;
            BLLSession.IUserService.ModifyModel(userInfo);
            //重新保存信息到Session和写入到Cookies
            WebHelper.OperateContext.Current.SetUserToSessionAndCookies(userInfo, true);
            return Redirect("/admin");
        }

    }
}