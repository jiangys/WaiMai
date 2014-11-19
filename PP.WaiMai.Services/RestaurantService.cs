using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.Services;
using PP.WaiMai.Contracts.ViewModels;
using PP.WaiMai.DaoCfg;

namespace PP.WaiMai.Services
{
    public class RestaurantService : IRestaurantService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");
        public IList<RestaurantViewModel> GetList()
        {
            return _sqlMap.QueryForList<RestaurantViewModel>("qryRestaurant", null);
        }


        public int Add(Contracts.Models.Restaurant model)
        {
            Object obj = _sqlMap.Insert("insRestaurant", model);
            return (int)obj;
        }

        public bool Update(Contracts.Models.Restaurant model)
        {
            Object obj = _sqlMap.Update("updRestaurant", model);
            return true;
        }

        public bool Delete(int Id)
        {
            _sqlMap.Delete("delRestaurant", Id);
            return true;
        }

        public Contracts.Models.Restaurant GetModel(int Id)
        {
            return (Restaurant)_sqlMap.QueryForObject("qryRestaurantById", Id);
        }
    }
}
