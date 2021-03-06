﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model
{
    [MetadataType(typeof(FoodMenuCategoryValidate))]
    public partial class FoodMenuCategory
    {

    }
    public class FoodMenuCategoryValidate
    {
        [DisplayName("选择餐厅：")]
        [Required(ErrorMessage = "请填写选择餐厅")]
        public string RestaurantID { get; set; }
        [DisplayName("类别名称：")]
        [Required(ErrorMessage = "请填写类别名称")]
        public string CName { get; set; }
        [DisplayName("是否销售：")]
        public bool IsSale { get; set; }
    }
}
