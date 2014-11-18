using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.WebHelper;

namespace WHTR.WaiMai.Web.Areas.Admin.Controllers
{
    public class RestaurantController : BaseController
    {
        //
        // GET: /Admin/Restaurant/
        public ActionResult Index()
        {
            var modelList = OperateHelper.IRestaurantService.GetList();
            return View(modelList);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                model.Version = 1;
                var modelList = OperateHelper.IRestaurantService.Add(model);
                return JsonMsgOk("增加成功", "/Admin/Restaurant");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }
        public ActionResult Edit(int id)
        {
            var model = OperateHelper.IRestaurantService.GetModel(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                var modelList = OperateHelper.IRestaurantService.Update(model);
                return JsonMsgOk("编辑成功", "/Admin/Restaurant");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }
        [HttpPost]
        public ActionResult Del(int id)
        {
            OperateHelper.IRestaurantService.Delete(id);
            return JsonMsgOk("删除成功", "/Admin/Restaurant");
        }
    }
}