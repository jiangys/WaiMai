using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.ViewModels;
using PP.WaiMai.WebHelper;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            var modelList = OperateHelper.IOrderService.GetTodayList();
            ViewBag.OrderList = modelList;

            var isDo = true;
            var doOrderValue = OperateHelper.IConfigService.GetConfigValue("DoOrder");
            if (doOrderValue != null)
            {
                var doOrderModel = JsonConvert.DeserializeObject<ConfigDoOrderViewModel>(doOrderValue);
                if (doOrderModel.DoTime == DateTime.Now.ToShortDateString())
                {
                    isDo = doOrderModel.IsDo;
                }
            }
            ViewBag.IsDo = isDo;
            return View();
        }
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
            OperateHelper.IConfigService.Update(configModel);
            return JsonMsgOk();
        }
    }
}