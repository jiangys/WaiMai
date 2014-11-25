using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PagedList;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Admin/Order/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = BLLSession.IOrderService.GetListBy(m => !m.IsDel).OrderByDescending(m => m.OrderID).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.FoodMenu.MenuName.Contains(Keyword) || m.NickName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        [HttpPost]
        public ActionResult Del(int id)
        {
            BLLSession.IOrderService.DeleteBy(m => m.OrderID == id);
            return JsonMsgOk("删除成功", "/Admin/Restaurant");
        }
    }
}