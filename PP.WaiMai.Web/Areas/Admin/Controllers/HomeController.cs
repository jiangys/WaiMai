using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;
using PP.WaiMai.Util.Security;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            DateTime currDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //得到所有的订单列表
            ViewBag.OrderList = BLLSession.IOrderService.GetListBy(m => m.OrderStatus == (int)OrderStatusEnum.Handle && m.CreateDate > currDate);
            //判断当前的订餐状态，ture为可订中
            ViewBag.IsDo = DoOrder();
            return View();
        }
        /// <summary>
        /// 订餐状态
        /// </summary>
        /// <returns></returns>
        private bool DoOrder()
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
            return isDo;
        }

        /// <summary>
        /// 是否停止订餐
        /// </summary>
        /// <param name="isDo"></param>
        /// <returns></returns>
        public ActionResult ChangeDoOrderState(bool isDo)
        {
            var model = new ConfigDoOrderViewModel()
            {
                DoTime = DateTime.Now.ToShortDateString(),
                IsDo = isDo
            };
            var modelJson = JsonConvert.SerializeObject(model);
            var configModel = new Config()
            {
                ConfigName = "DoOrder",
                ConfigValue = modelJson
            };
            BLLSession.IConfigService.ModifyModel(configModel);
            return JsonMsgOk();
        }

        public ActionResult test()
        {
            return View();
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ResetPassword()
        {

            return View();
        }
        /// <summary>
        /// 重置密码 
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResetPassword(int userID)
        {
            if (!OperateHelper.IsLogin())
            {
                return JsonMsgNoOk("对不起，你没权限操作");
            }
            if (!OperateHelper.User.IsAdmin)
            {
                return JsonMsgNoOk("对不起，你没权限操作");
            }
            var resetPassword = UEncypt.MD5("pp123456");
            BLLSession.IUserService.Modify(new Model.User() { UserID = userID, Password = resetPassword }, "Password");
            return JsonMsgOk("重置密码成功，下次登陆生效");
        }
    }
}