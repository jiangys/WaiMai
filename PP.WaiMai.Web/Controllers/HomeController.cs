using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.Model;

namespace PP.WaiMai.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.RestaurantList = BLLSession.IRestaurantService.GetListBy(m => m.IsEnable).Take(2).ToList();
            //获取吐槽列表  
            int totalCount = 0;
            var sarcasmList = BLLSession.ISarcasmService.GetPagedList(1, 10, ref totalCount, m => !m.IsDel, m => m.SarcasmID, false);
            var query = from m in sarcasmList
                        select new SarcasmHomeViewModel
                        {
                            UserName = m.User.UserName,
                            CreateTime = Util.StringFormat.DateTimeFormat.DateStringFromNow(m.CreateDate),
                            Content = m.Content,
                            CommentCount = m.Comment.Count()
                        };
            ViewBag.SarcasmList = query.ToList();
            return View();
        }
        /// <summary>
        /// 意见反馈
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Feedback(string contentMsg)
        {
            if (string.IsNullOrEmpty(contentMsg))
            {
                return JsonMsgNoOk("请填写反馈内容");
            }
            Feedback model = new Feedback();
            model.ContentMsg = contentMsg;
            model.CreateTime = DateTime.Now;
            if (OperateHelper.IsLogin())
            {
                model.UserID = CurrentUser.UserID;
            }
            BLLSession.IFeedbackService.Add(model);
            return JsonMsgOk("反馈成功");
        }
    }
}