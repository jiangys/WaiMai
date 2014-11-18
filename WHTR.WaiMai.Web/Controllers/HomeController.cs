using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHTR.WaiMai.Contracts.Services;
using WHTR.WaiMai.WebHelper;

namespace WHTR.WaiMai.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var A = GetInternalIP();
            var restaurantModel = OperateHelper.IRestaurantService.GetList().Where(m => m.IsEnable == true).FirstOrDefault();
            var foodMenuList = OperateHelper.IFoodMenuService.GetList(restaurantModel.Id);

            ViewBag.FoodMenuList = foodMenuList;
            ViewBag.RestaurantModel = restaurantModel;

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