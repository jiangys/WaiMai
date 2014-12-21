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
            ViewBag.RestaurantList = BLLSession.IRestaurantService.GetListBy(m=>m.IsEnable).Take(2).ToList();
            return View();
        }
    }
}