using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model;
using Newtonsoft.Json;
using PP.WaiMai.Model.ViewModels;

namespace PP.WaiMai.Web.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            var doModeType = BLLSession.IConfigService.GetModel(m => m.ConfigName == "DoModeType");
            if (doModeType != null && !string.IsNullOrEmpty(doModeType.ConfigValue))
            {
                var doModeTypeValue = JsonConvert.DeserializeObject<ConfigDoModeTypeViewModel>(doModeType.ConfigValue);
                if (doModeTypeValue.DoTime.ToShortDateString() == DateTime.Now.ToShortDateString() && !doModeTypeValue.IsDayMode)
                {
                    var list = BLLSession.IOrderService.GetListBy(m => m.CreateDate > doModeTypeValue.DoTime && m.CreateDate < DateTime.Now);
                    ViewBag.IsDayMode = false;
                    return View(list);
                }
            }
            var startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var modelList = BLLSession.IOrderService.GetListBy(m => m.CreateDate > startDate && m.CreateDate < DateTime.Now);
            ViewBag.IsDayMode = true;
            return View(modelList);
        }
        [HttpPost]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                model.TotalCount = 1;
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                model.Version = 1;
                var result = BLLSession.IOrderService.Add(model);
                return JsonMsgOk("下单成功", "/Order/Index");
            }
            return View();
        }
    }
}