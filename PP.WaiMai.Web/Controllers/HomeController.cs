using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model.ViewModels;

namespace PP.WaiMai.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var restaurantModel = BLLSession.IRestaurantService.GetListBy(m => m.IsEnable == true).FirstOrDefault();
            var foodMenuList = BLLSession.IFoodMenuService.GetListBy(m => m.FoodMenuCategory.RestaurantID == restaurantModel.RestaurantID);

            ViewBag.FoodMenuList = foodMenuList;
            ViewBag.RestaurantModel = restaurantModel;

            #region --状态
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
            #endregion


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //获取内网IP
        private string GetInternalIP()
        {
            System.Net.IPHostEntry host;
            string localIP = "?";
            host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}