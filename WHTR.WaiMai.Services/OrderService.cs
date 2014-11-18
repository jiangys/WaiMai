using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.Contracts.Services;
using WHTR.WaiMai.Contracts.ViewModels;
using WHTR.WaiMai.DaoCfg;

namespace WHTR.WaiMai.Services
{
    public class OrderService : IOrderService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");

        public IList<OrderViewModel> GetList()
        {
            return _sqlMap.QueryForList<OrderViewModel>("qryOrder", null);
        }
        /// <summary>
        /// 获取今天数据
        /// </summary>
        /// <returns></returns>
        public IList<OrderViewModel> GetTodayList()
        {
            return _sqlMap.QueryForList<OrderViewModel>("qryOrderForToday", null);
        }

        public int Add(Order model)
        {
            Object obj = _sqlMap.Insert("insOrder", model);
            return (int)obj;
        }

        public bool Delete(int Id)
        {
            _sqlMap.Delete("delOrder", Id);
            return true;
        }
    }
}
