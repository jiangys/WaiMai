using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.WebHelper;

namespace WHTR.WaiMai.Web.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            var modelList = OperateHelper.IOrderService.GetTodayList();
            return View(modelList);
        }
        [HttpPost]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                model.TotalCount = 1;
                model.CreateDate = DateTime.Now;
                model.IsDel = false;
                model.Version = 1;
                var result = OperateHelper.IOrderService.Add(model);
                return JsonMsgOk("下单成功", "/Order/Index");
            }
            return View();
        }
	}
}