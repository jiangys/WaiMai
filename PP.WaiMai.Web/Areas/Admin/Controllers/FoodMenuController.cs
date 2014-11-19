using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PagedList;
using PP.WaiMai.Contracts.Models;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class FoodMenuController : BaseController
    {
        //
        // GET: /Admin/FoodMenu/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = OperateHelper.IFoodMenuService.GetList()
                .OrderByDescending(m => m.Id).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.MenuName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        public ActionResult Add()
        {
            var modelList = OperateHelper.IFoodMenuCategoryService.GetList();
            ViewBag.FoodMenuCategoryList = modelList.Select(m => new SelectListItem()
            {
                Text = m.RestaurantName + "→" + m.CName,
                Value = m.Id.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FoodMenu model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                model.Version = 1;
                var modelList = OperateHelper.IFoodMenuService.Add(model);
                return JsonMsgOk("增加菜单成功", "/Admin/FoodMenu");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }


        public ActionResult Edit(int id)
        {
            var modelList = OperateHelper.IFoodMenuCategoryService.GetList();
            ViewBag.FoodMenuCategoryList = modelList.Select(m => new SelectListItem()
            {
                Text = m.RestaurantName + "→" + m.CName,
                Value = m.Id.ToString()
            }).ToList();
            var model = OperateHelper.IFoodMenuService.GetModel(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodMenu model)
        {
            if (ModelState.IsValid)
            {
                var modelList = OperateHelper.IFoodMenuService.Update(model);
                return JsonMsgOk("编辑成功", "/Admin/FoodMenu");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }
        [HttpPost]
        public ActionResult Del(int id)
        {
            OperateHelper.IFoodMenuService.Delete(id);
            return JsonMsgOk("删除成功", "/Admin/FoodMenu");
        }

    }
}