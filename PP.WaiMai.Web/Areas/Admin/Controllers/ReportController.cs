using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Admin/Report/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RepUser(int? page, string Keyword)
        {
            var model = BLLSession.IUserService.GetListBy(m => !m.IsDel).OrderBy(m=>m.UserID).Skip(2).ToList();
            ViewBag.AllAmount = model.Sum(m=>m.Amount);
            if (!string.IsNullOrEmpty(Keyword))
            {
                //model = model.Where(m => m.UserName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }
	}
}