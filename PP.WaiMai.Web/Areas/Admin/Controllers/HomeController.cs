using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.Model;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            var startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var modelList = BLLSession.IOrderService.GetListBy(m => m.CreateDate > startDate && m.CreateDate < DateTime.Now);
            ViewBag.OrderList = modelList;

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
            BLLSession.IConfigService.ModifyModel(configModel);
            return JsonMsgOk();
        }
    }
}