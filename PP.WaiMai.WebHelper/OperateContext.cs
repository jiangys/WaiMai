using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PP.WaiMai.WebHelper
{
    public class OperateContext
    {
        #region --上下文及业务仓储
        /// <summary>
        /// 业务仓储
        /// </summary>
        public IService.IServiceSession ServiceSession;
        public OperateContext()
        {
            ServiceSession = new PP.WaiMai.Service.ServiceSession();//DI.SpringHelper.GetObject<IService.IServiceSession>("ServiceSession");
        }
        /// <summary>
        /// 获取当前操作上下文 (为每个处理浏览器请求的服务器线程单独创建操作上下文)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                OperateContext oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }
        #endregion

        #region Http上下文及相关属性
        /// <summary>
        /// Http上下文
        /// </summary>
        HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        HttpResponse Response
        {
            get
            {
                return ContextHttp.Response;
            }
        }

        HttpRequest Request
        {
            get
            {
                return ContextHttp.Request;
            }
        }

        System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return ContextHttp.Session;
            }
        }
        #endregion
    }
}
