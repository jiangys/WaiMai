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
            //判断当前的订餐状态，ture为可订中
            ViewBag.IsDo = DoOrder();
            //当前模式
            ViewBag.IsDayMode = DoModeType();
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
        /// 当前模式
        /// </summary>
        /// <returns></returns>
        private bool DoModeType()
        {
            var isDayMode = true;
            var doModeType = BLLSession.IConfigService.GetModel(m => m.ConfigName == "DoModeType");
            if (doModeType != null && !string.IsNullOrEmpty(doModeType.ConfigValue))
            {
                var doModeTypeValue = JsonConvert.DeserializeObject<ConfigDoModeTypeViewModel>(doModeType.ConfigValue);
                if (doModeTypeValue.DoTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    isDayMode = doModeTypeValue.IsDayMode;
                }
            }
            return isDayMode;
        }

        /// <summary>
        /// 前台异步控制是否停止订餐
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

        public ActionResult ChangeDoModeType(bool isDayMode)
        {
            var model = new ConfigDoModeTypeViewModel()
            {
                DoTime = DateTime.Now,
                IsDayMode = isDayMode
            };
            var modelJson = JsonConvert.SerializeObject(model);
            var configModel = new Config()
            {
                ConfigName = "DoModeType",
                ConfigValue = modelJson
            };
            BLLSession.IConfigService.ModifyModel(configModel);
            return JsonMsgOk();
        }
    }
}