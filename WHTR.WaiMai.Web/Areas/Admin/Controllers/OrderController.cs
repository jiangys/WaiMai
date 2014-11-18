﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHTR.WaiMai.WebHelper;
using PagedList;

namespace WHTR.WaiMai.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Admin/Order/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = OperateHelper.IOrderService.GetList().OrderByDescending(m => m.Id).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.MenuName.Contains(Keyword)||m.NickName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        [HttpPost]
        public ActionResult Del(int id)
        {
            OperateHelper.IOrderService.Delete(id);
            return JsonMsgOk("删除成功", "/Admin/Restaurant");
        }
	}
}