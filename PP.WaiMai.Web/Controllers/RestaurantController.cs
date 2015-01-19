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
    public class RestaurantController : BaseController
    {
        //
        // GET: /Restaurant/
        public ActionResult Index(int id)
        {
            var restaurantModel = BLLSession.IRestaurantService.GetListBy(m => m.IsEnable == true && !m.IsDel&&m.RestaurantID==id).FirstOrDefault();
            if (restaurantModel == null)
            {
                return View();
            }
            var foodMenuList = BLLSession.IFoodMenuService.GetListBy(m => m.FoodMenuCategory.RestaurantID == restaurantModel.RestaurantID && !m.IsDel);
            var foodMenuIdList = foodMenuList.Select(m => m.FoodMenuID);
            var orderList = BLLSession.IOrderService.GetListBy(m => foodMenuIdList.Contains(m.FoodMenuID) && !m.IsDel);

            var foodMenuViewList = foodMenuList.Select(m => new FoodMenuViewModel()
            {
                FoodMenuID = m.FoodMenuID,
                FoodMenuCategoryID = m.FoodMenuCategoryID,
                CName = m.FoodMenuCategory.CName,
                IsSale = m.IsSale,
                MenuName = m.MenuName,
                Price = m.Price,
                RestaurantName = restaurantModel.RestaurantName,
                TotalCount = orderList.Where(u => u.FoodMenuID == m.FoodMenuID).Sum(u => u.TotalCount)
            }).ToList();

            ViewBag.FoodMenuViewList = foodMenuViewList;
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
	}
}