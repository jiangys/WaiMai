using PP.WaiMai.Model;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.Util.Security;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PP.WaiMai.Web.Controllers
{
    public class AccountController : BaseController
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (OperateContext.Current.Login(model))
                {
                    return JsonMsgOk("登陆成功");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误.");
                }
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk("用户名或密码错误");
        }


        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Password = "pp123456";
            model.IPAddress = Util.IPAddress.GetInternalIP();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Util.Security.UEncypt.DESEncrypt(model.Password);
                model.Amount = 0;
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                BLLSession.IUserService.Add(model);
                //保存信息到Session和写入到Cookies
                WebHelper.OperateContext.Current.SetUserToSessionAndCookies(model, true);
                return Redirect("/home");
            }

            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebHelper.OperateContext.Current.LogOff();
            return RedirectToAction("Index", "Home");
        }

        #region --修改密码+ChangePassword
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!OperateHelper.IsLogin())
                {
                    return JsonMsgNoOk("请先登陆");
                }
                var oldPassword = UEncypt.DESEncrypt(model.OldPassword);
                var newModel = BLLSession.IUserService.GetListBy(m => m.UserID == OperateHelper.User.UserID && m.Password == oldPassword).FirstOrDefault();
                if (newModel != null)
                {
                    newModel.Password = UEncypt.DESEncrypt(model.NewPassword); 
                    BLLSession.IUserService.ModifyModel(newModel);
                    return JsonMsgOk("修改密码成功，下次登陆生效");
                }
                return JsonMsgErr("原密码错误");
            }
            return JsonMsgErr("修改密码失败，请联系管理员");
        }
        #endregion
    }
}