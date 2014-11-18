using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.Contracts.ViewModels;

namespace WHTR.WaiMai.Contracts.Services
{
  public interface IRestaurantService
    {
      //查询所有的餐厅
     IList<RestaurantViewModel> GetList();

     /// <summary>
     /// 增加一条数据
     /// </summary>
     int Add(Restaurant model);
     /// <summary>
     /// 更新一条数据
     /// </summary>
     bool Update(Restaurant model);
     /// <summary>
     /// 删除一条数据
     /// </summary>
     bool Delete(int Id);
     /// <summary>
     /// 得到一个对象实体
     /// </summary>
     Restaurant GetModel(int Id);
    }
}
