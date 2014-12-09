using Newtonsoft.Json;
using PP.WaiMai.Model;
using PP.WaiMai.Model.ViewModels;
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
        //用户登陆
        const string User_InfoKey = "UserKey";

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

        #region --保存用户登陆信息到Session and Cookies + SetSessionAndCookies(UserInfo userInfo)
        /// <summary>
        /// 保存用户登陆信息到Session and Cookies
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="IsCookie">true为保存Cookie</param>
        public void SetUserToSessionAndCookies(User user, bool IsCookie)
        {
            if (user != null)
            {
                User = user;//保存信息到Session
                if (IsCookie)//存入Cookie
                {
                    Uxiaoyuan.Common.UCookies.WriteCookies(User_InfoKey, 1, JsonConvert.SerializeObject(User));
                }
            }
        }
        #endregion

        #region 当前用户对象 + Model.UserInfo User
        // <summary>
        /// 当前用户对象
        /// </summary>
        public User User
        {
            get { return Session[User_InfoKey] as User; }
            set { Session[User_InfoKey] = value; }
        }
        #endregion

        #region 会员登录方法 + bool LoginUser(MODEL.ViewModel.LoginUser usrPara)
        /// <summary>
        /// 会员登录方法
        /// </summary>
        /// <param name="usrPara"></param>
        public bool Login(LoginViewModel model)
        {
            //到业务成查询
            var user = ServiceSession.IUserService.Login(model.UserName, model.Password);
            if (user != null)
            {
                //保存用户数据(Session or Cookie)
                SetUserToSessionAndCookies(user, true);
                return true;
            }
            return false;
        }
        #endregion

        #region 判断当前用户是否登陆 +bool IsLogin()
        /// <summary>
        /// 判断当前用户是否登陆 true为登陆
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            //验证用户是否登陆(Session && Cookie)
            if (Session[User_InfoKey] == null)
            {
                if (Request.Cookies[User_InfoKey] == null)
                {
                    return false;
                }
                else//如果有cookie则从cookie中获取用户查询相关数据存入 Session
                {
                    string strUserInfo = Uxiaoyuan.Common.UCookies.GetCookies(User_InfoKey);
                    if (string.IsNullOrEmpty(strUserInfo))
                    {
                        return false;
                    }
                    //序列化返回信息
                    User = JsonConvert.DeserializeObject<User>(strUserInfo);
                }
            }
            return true;
        }
        #endregion

        #region 退出当前登陆
        public bool LogOff()
        {
            Session[User_InfoKey] = null;
            Uxiaoyuan.Common.UCookies.DelCookie(User_InfoKey);
            return true;
        }
        #endregion
    }
}
