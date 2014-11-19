using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.ViewModels;

namespace PP.WaiMai.Contracts.Services
{
    public interface IFoodMenuService
    {
        IList<FoodMenuViewModel> GetList();
        /// <summary>
        /// 通过餐厅Id获取所有的菜单列表
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        IList<FoodMenuViewModel> GetList(int RestaurantId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(FoodMenu model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(FoodMenu model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FoodMenu GetModel(int Id);
    }
}
