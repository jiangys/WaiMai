using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP.WaiMai.Web.Filters
{
    public class RequiredAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        #region 验证方法 - 在 ActionExcuting过滤器之前执行
        /// <summary>
        /// 验证方法 - 在 ActionExcuting过滤器之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //获取区域名
            string strArea = filterContext.RouteData.DataTokens.Keys.Contains("area") ? filterContext.RouteData.DataTokens["area"].ToString().ToLower() : "";

            //获取域名
            //var subdomain = System.Web.Mvc.RouteData.Values["subdomain"];
            //var aa = HttpContext.Current.Request.Url.Host;
            //Common.LogHelper.WriteLog("地址:"+aa);
            if (strArea == "admin")
            {
                //验证是否要跳过登陆验证，如果不要，则继续判断
                //if (DoesValidate<Helper.Attributes.NeedAuthorizeAttribute>(filterContext) && !DoesSkip<Helper.Attributes.SkipLoginAttribute>(filterContext))
                //{
                //    if (!OperateContext.Current.IsLogin())
                //    {
                //        filterContext.Result = OperateContext.Current.Redirect("/Admin/Home/login", filterContext.ActionDescriptor);
                //    }
                //}
            }
            //2.检查被请求的方法和控制器是否有Validate标签，如果有，则验证；如果没有，则不验证
            else if (DoesValidate<WebHelper.Attributes.NeedAuthorizeAttribute>(filterContext))
            {
                //验证用户是否登陆(Session && Cookie)
                //if (!OperateContext.Current.IsLogin())
                //{
                //    string url = HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl.ToString());
                //    string nowUrl = "/Account/Login" + "?ReturnUrl=" + url;
                //    filterContext.Result = new RedirectResult(nowUrl);
                //}
            }
        }
        #endregion

        /// <summary>
        /// 是否需要验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        bool DoesValidate<T>(System.Web.Mvc.AuthorizationContext filterContext) where T : Attribute
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(T), false) ||
                    filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(T), false))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否跳过验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        bool DoesSkip<T>(System.Web.Mvc.AuthorizationContext filterContext) where T : Attribute
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(T), false) &&
                    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(T), false))
            {
                return false;
            }
            return true;
        }


    }
}