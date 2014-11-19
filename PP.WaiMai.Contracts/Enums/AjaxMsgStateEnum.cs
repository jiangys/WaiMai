using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Contracts.Enums
{
    public enum AjaxMsgStateEnum
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        OK = 1,
        /// <summary>
        /// 操作因为某种原因失败（业务级：比如登陆密码错误）
        /// </summary>
        NoOK = 2,
        /// <summary>
        /// 没有登录
        /// </summary>
        NoLogin = 3,
        /// <summary>
        /// 没有权限
        /// </summary>
        NoPerssion = 4,
        /// <summary>
        /// 异常
        /// </summary>
        Err = 5,
        /// <summary>
        /// 异常
        /// </summary>
        Other = 6
    }
}
