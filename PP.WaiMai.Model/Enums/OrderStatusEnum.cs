using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.Enums
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatusEnum
    {
        /// <summary>
        /// 下单成功，处理中
        /// </summary>
        Handle = 0,
        /// <summary>
        /// 交易成功
        /// </summary>
        Succeed = 1,
        /// <summary>
        /// 订单取消
        /// </summary>
        Cancel = 2
    }
}
