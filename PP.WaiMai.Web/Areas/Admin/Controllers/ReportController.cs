using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PP.WaiMai.Model.RepSearchModels;
using System.Linq.Expressions;
using PP.WaiMai.Model;

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
            var model = BLLSession.IUserService.GetListBy(m => !m.IsDel).OrderBy(m => m.UserID).Skip(2).ToList();
            ViewBag.AllAmount = model.Sum(m => m.Amount);
            if (!string.IsNullOrEmpty(Keyword))
            {
                //model = model.Where(m => m.UserName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        public ActionResult RepOrder(RepOrderSearchModel searchModel)
        {

            Expression<Func<Order, bool>> func = m => m.IsDel == false;

            if (searchModel.beginTime != null)
            {
                DateTime beginTime = DateTime.Parse(searchModel.beginTime);
                func = func.And(m => m.CreateDate >= beginTime);
            }
            if (searchModel.endTime != null)
            {
                DateTime endTime = DateTime.Parse(searchModel.endTime);
                func = func.And(m => m.CreateDate <= endTime);
            }
            if (searchModel.userName != null)
            {
                func = func.And(m => m.User.UserName.Contains(searchModel.userName));
            }

            int rowCount = 0;
            var pageIndex = searchModel.page ?? 1;
            var pageSize = 15;

            var pageData = BLLSession.IOrderService.GetPagedList(pageIndex, pageSize, ref rowCount, func, m => m.OrderID, false);

            ViewBag.OnePageOfOrders = new StaticPagedList<Order>(pageData, pageIndex, pageSize, rowCount);

            ViewBag.SearchModel = searchModel;

            return View();
        }

        /// <summary>
        /// 消费报表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        public ActionResult RepExpendLog(int? page, string Keyword)
        {

            var model = BLLSession.IExpendLogService.GetListBy(m => true).OrderByDescending(m => m.ExpendLogID);
            if (!string.IsNullOrEmpty(Keyword))
            {
                //model = model.Where(m => m.UserID.Contains(Keyword) || m.User.UserName.Contains(Keyword)).ToList();
            }
            //剩余总金额
            ViewBag.RemainAmount = model.Sum(m => m.RechargeAmount) - model.Sum(m => m.ConsumeAmount);
            return View(model.ToPagedList(page ?? 1, 15));
        }
    }
}