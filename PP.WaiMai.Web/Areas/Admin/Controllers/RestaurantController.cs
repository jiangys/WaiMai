using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class RestaurantController : BaseController
    {
        //
        // GET: /Admin/Restaurant/
        public ActionResult Index()
        {
            var modelList = BLLSession.IRestaurantService.GetListBy(m => m.IsDel == false);
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
                var modelList = BLLSession.IRestaurantService.Add(model);
                return JsonMsgOk("增加成功", "/Admin/Restaurant");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }
        public ActionResult Edit(int id)
        {
            var model = BLLSession.IRestaurantService.GetModel(m => m.RestaurantID == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                var modelList = BLLSession.IRestaurantService.Modify(model, "RestaurantName", "SendOutCount", "TakeoutPhone", "Description", "IsEnable");
                return JsonMsgOk("编辑成功", "/Admin/Restaurant");
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return JsonMsgNoOk();
        }

        /// <summary>
        /// 逻辑删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Del(int id)
        {
            BLLSession.IRestaurantService.Modify(new Restaurant() { RestaurantID = id, IsDel = true }, "IsDel");
            return JsonMsgOk("删除成功", "/Admin/Restaurant");
        }
    }
}