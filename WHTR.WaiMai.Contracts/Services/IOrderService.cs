using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.Contracts.ViewModels;

namespace WHTR.WaiMai.Contracts.Services
{
    public interface IOrderService
    {
        IList<OrderViewModel> GetList();
        /// <summary>
        /// 获取今天订单数据
        /// </summary>
        /// <returns></returns>
        IList<OrderViewModel> GetTodayList();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Order model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Id);
    }
}
