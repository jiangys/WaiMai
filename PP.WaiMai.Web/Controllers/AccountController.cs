using PP.WaiMai.Model.ViewModels;
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
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //var user = await UserManager.FindAsync(model.UserName, model.Password);
                //if (user != null)
                //{
                //    await SignInAsync(user, model.RememberMe);
                //    return RedirectToLocal(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid username or password.");
                //}
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
	}
}