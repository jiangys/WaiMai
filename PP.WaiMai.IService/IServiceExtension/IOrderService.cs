using PP.WaiMai.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.IService
{
    partial interface IOrderService : IBaseService<Order>
    {

        /// <summary>
        /// 订单取消
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <returns></returns>
        bool OrderCancel(int id);
    }
}
