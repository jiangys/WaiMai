﻿using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PP.WaiMai.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            //获取本地的IP地址
            var ip = WaiMai.Util.IPAddress.GetInternalIP();
            //从数据库里查找，看有没有相关的。如果存在，则显示出用户名

            return View();
        }
        public ActionResult LoginDialog()
        {
            //获取本地的IP地址
            var ip = WaiMai.Util.IPAddress.GetInternalIP();
            //从数据库里查找，看有没有相关的。如果存在，则显示出用户名

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = OperateContext.Current.Login(model);
                if (user != null)
                {
                    return Redirect("/home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
    }
}