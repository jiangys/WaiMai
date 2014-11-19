using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Contracts.ViewModels
{
    public class FoodMenuCategoryViewModel
    {
        /// <summary>
        /// 菜单类别Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string RestaurantName { get; set; }
        /// <summary>
        /// 菜单类别名称
        /// </summary>
        public string CName { get; set; }

    }
}
