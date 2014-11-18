using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WHTR.WaiMai.Contracts.Enums;

namespace WHTR.WaiMai.WebHelper
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 操作上下文
        /// </summary>
        public OperateContext OperateHelper
        {
            get { return OperateContext.Instance(); }
        }

        #region 生成Json格式的返回值 +ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        /// <summary>
        /// 生成Json格式的返回值
        /// </summary>
        /// <param name="statu"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="backurl"></param>
        /// <returns></returns>
        public ActionResult RedirectAjax(AjaxMsgStateEnum state = AjaxMsgStateEnum.OK, string msg = "", string backurl = "", object data = null)
        {
            WHTR.WaiMai.Contracts.FormatModels.AjaxMsgModel ajax = new WHTR.WaiMai.Contracts.FormatModels.AjaxMsgModel()
            {
                State = state,
                Msg = msg,
                BackUrl = backurl,
                Data = data

            };
            //将格式对象装入JsonResult,等待被序列化成json字符串返回给浏览器
            return new JsonResult() { Data = ajax, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion

        #region 1.0 输出统一Ajax消息格式 +ActionResult JsonMsg

        /// <summary>
        /// 1.0 输出 统一Ajax消息格式
        /// </summary>
        /// <param name="statu">处理状态</param>
        /// <param name="msg">处理消息</param>
        /// <param name="backUrl">返回跳转url</param>
        /// <param name="data">返回处理数据</param>
        /// <returns></returns>
        public ActionResult JsonMsg(AjaxMsgStateEnum state = AjaxMsgStateEnum.OK, string msg = "", string backUrl = "", object data = null)
        {
            return RedirectAjax(state, msg, backUrl, data);
        }
        #endregion

        #region 1.1 辅助 消息格式方法  JsonMsgOk 等
        public ActionResult JsonMsgOk(string msg = "操作成功", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStateEnum.OK, msg, backUrl, data);
        }

        public ActionResult JsonMsgNoOk(string msg = "操作失败", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStateEnum.NoOK, msg, backUrl, data);
        }

        public ActionResult JsonMsgErr(string msg = "操作异常", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStateEnum.Err, msg, backUrl, data);
        }

        public ActionResult JsonMsgErr(Exception ex, string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStateEnum.Err, ex.Message, backUrl, data);
        }
        public ActionResult JsonMsgOther(string msg = "操作失败", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStateEnum.Other, msg, backUrl, data);
        }
        #endregion
    }
}
