using PP.WaiMai.Model;
using PP.WaiMai.Model.ViewModels;
using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Newtonsoft.Json;

namespace PP.WaiMai.Web.Controllers
{
    public class TuCaoController : BaseController
    {
        //
        // GET: /TuCao/
        public ActionResult Index(int? page)
        {
            var pageIndex = page ?? 1; //MembershipProvider expects a 0 for the first page
            var pageSize = 15;
            int totalCount = 0; // will be set by call to GetAllUsers due to _out_ paramter :-|
            var model = BLLSession.ISarcasmService.GetPagedList(pageIndex, pageSize, ref totalCount, m => !m.IsDel, m => m.SarcasmID, false);
            var modelAsIPagedList = new StaticPagedList<Sarcasm>(model, pageIndex, pageSize, totalCount);
            //获取当前所有的吐槽记录ID集合
            var sarcasmIDs = model.Select(m => m.SarcasmID).ToList();
            //获取当前吐槽的评论列表
            ViewBag.CommentList = BLLSession.ICommentService.GetListBy(m => sarcasmIDs.Contains(m.SarcasmID) && !m.IsDel)
                .OrderByDescending(m => m.CommentID).ToList();

            return View(modelAsIPagedList);
        }
        [HttpGet]
        public ActionResult Publish()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Publish(SarcasmViewModel model)
        {
            if (!OperateHelper.IsLogin())
            {
                return RedirectToAction("Login", "Account", new { ReturnUrl = Url.Action("Publish") });
            }
            if (ModelState.IsValid)
            {
                Sarcasm sarcasmModel = new Sarcasm();
                sarcasmModel.Content = model.Content;
                sarcasmModel.CreateDate = DateTime.Now;
                sarcasmModel.IsDel = false;
                //2为匿名用户
                sarcasmModel.UserID = (model.Type == 2) ? 2 : CurrentUser.UserID;

                BLLSession.ISarcasmService.Add(sarcasmModel);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult GetSarcasm()
        {
            int totalCount = 0;
            //获取前10条记录
            var sarcasmList = BLLSession.ISarcasmService.GetPagedList(1, 10, ref totalCount, m => !m.IsDel, m => m.SarcasmID, false);
            var query = from m in sarcasmList
                        select new 
                        {
                            UserName = m.User.UserName,
                            CreateTime = m.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            Content = m.Content,
                            CommentCount = m.Comment.Count()
                        };

            return Json(new { data = JsonConvert.SerializeObject(query.ToList()) });
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Comment(int sarcasmID, string content)
        {
            if (!OperateHelper.IsLogin())
            {
                return JsonMsgNoOk("请先登陆");
            }
            if (content == null || sarcasmID == 0)
            {
                return JsonMsgNoOk("请填写评论内容");
            }

            Comment model = new Model.Comment();
            model.Content = content;
            model.CreateTime = DateTime.Now;
            model.IsDel = false;
            model.SarcasmID = sarcasmID;
            model.UserID = CurrentUser.UserID;
            BLLSession.ICommentService.Add(model);


            //获取当前吐槽所有的评论
            var CurCommentList = BLLSession.ICommentService.GetListBy(m => m.SarcasmID == sarcasmID && !m.IsDel);
            var UserIDs = CurCommentList.Select(m => m.UserID).Distinct();
            var UserList = BLLSession.IUserService.GetListBy(m => UserIDs.Contains(m.UserID));

            var CommnetList = (from a in CurCommentList
                               join c in UserList on a.UserID equals c.UserID
                               select new
                                 {
                                     a.Content,
                                     CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                     c.UserName
                                 }).OrderByDescending(m => m.CreateTime).ToList();

            return JsonMsgOk("评论成功", null, JsonConvert.SerializeObject(CommnetList));
        }

    }
}