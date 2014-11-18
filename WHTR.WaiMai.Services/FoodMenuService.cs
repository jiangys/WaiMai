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
    public class FoodMenuService : IFoodMenuService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");
        public IList<FoodMenuViewModel> GetList()
        {
            return _sqlMap.QueryForList<FoodMenuViewModel>("qryFoodMenu", null);
        }
        public IList<FoodMenuViewModel> GetList(int RestaurantId)
        {
            return _sqlMap.QueryForList<FoodMenuViewModel>("qryFoodMenuByRestaurantId", RestaurantId);
        }
        public int Add(Contracts.Models.FoodMenu model)
        {
            Object obj = _sqlMap.Insert("insFoodMenu", model);
            return (int)obj;
        }

        public bool Update(Contracts.Models.FoodMenu model)
        {
            Object obj = _sqlMap.Update("updFoodMenu", model);
            return true;
        }

        public bool Delete(int Id)
        {
            _sqlMap.Delete("delFoodMenu", Id);
            return true;
        }

        public Contracts.Models.FoodMenu GetModel(int Id)
        {
            return (FoodMenu)_sqlMap.QueryForObject("qryFoodMenuById", Id);
        }
    }
}
