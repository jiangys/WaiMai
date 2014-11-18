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
    public class FoodMenuCategoryService : IFoodMenuCategoryService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");
        public IList<FoodMenuCategoryViewModel> GetList()
        {
            return _sqlMap.QueryForList<FoodMenuCategoryViewModel>("qryFoodMenuCategory", null);
        }

        public FoodMenuCategory GetModel(int id)
        {
            return (FoodMenuCategory)_sqlMap.QueryForObject("SelectByID", id);
        }

        public int Add(Contracts.Models.FoodMenuCategory model)
        {
            Object obj = _sqlMap.Insert("insFoodMenuCategory", model);
            return (int)obj;
        }

        public bool Update(Contracts.Models.FoodMenuCategory model)
        {
            Object obj = _sqlMap.Update("updFoodMenuCategory", model);
            return true;
            //throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            _sqlMap.Delete("delFoodMenuCategory", Id);
            return true;
        }
    }
}
