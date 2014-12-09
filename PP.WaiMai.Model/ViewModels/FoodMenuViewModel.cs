using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    public class FoodMenuViewModel
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int FoodMenuID { get; set; }
        /// <summary>
        ///  菜单类别Id
        /// </summary>
        public int FoodMenuCategoryID { get; set; }
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string RestaurantName { get; set; }
        /// <summary>
        /// 菜单类别名称
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        //价格
        public decimal Price { get; set; }
        /// <summary>
        /// 已售多少份
        /// </summary>
        public int TotalCount { get; set; }

        public bool IsSale { get; set; }
    }
}
