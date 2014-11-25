using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PagedList;
using PP.WaiMai.Model;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class FoodMenuCategoryController : BaseController
    {
        //
        // GET: /Admin/FoodMenuCategory/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = BLLSession.IFoodMenuCategoryService.GetListBy(m=>m.IsDel==false)
                .OrderByDescending(m => m.FoodMenuCategoryID).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.CName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        public ActionResult Add()
        {
            var modelList = BLLSession.IRestaurantService.GetListBy(m => m.IsDel == false);
            ViewBag.RestaurantList = modelList.Select(m => new SelectListItem()
            {
                Text = m.RestaurantName,
                Value = m.RestaurantID.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FoodMenuCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                model.Version = 1;
                var modelList = BLLSession.IFoodMenuCategoryService.Add(model);
                return JsonMsgOk("增加菜单成功", "/Admin/FoodMenuCategory");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }


        public ActionResult Edit(int id)
        {
            var modelList = BLLSession.IRestaurantService.GetListBy(m => m.IsDel == false);
            ViewBag.RestaurantList = modelList.Select(m => new SelectListItem()
            {
                Text = m.RestaurantName,
                Value = m.RestaurantID.ToString()
            }).ToList();
            var model = BLLSession.IFoodMenuCategoryService.GetModel(m=>m.FoodMenuCategoryID==id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodMenuCategory model)
        {
            if (ModelState.IsValid)
            {
                var modelList = BLLSession.IFoodMenuCategoryService.Modify(model, "RestaurantID", "CName", "IsSale");
                return JsonMsgOk("编辑菜单成功", "/Admin/FoodMenuCategory");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }
        [HttpPost]
        public ActionResult Del(int id)
        {
            BLLSession.IFoodMenuCategoryService.DeleteBy(m=>m.FoodMenuCategoryID==id);
            return JsonMsgOk("删除成功", "/Admin/FoodMenuCategory");
        }

    }
}