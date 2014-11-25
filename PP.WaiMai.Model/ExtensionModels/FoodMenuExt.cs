using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model
{
    [MetadataType(typeof(FoodMenuValidate))]
    public partial class FoodMenu
    {

    }
    public class FoodMenuValidate
    {
        [DisplayName("选择类别：")]
        [Required(ErrorMessage = "请填写选择类别")]
        public string FoodMenuCategoryID { get; set; }

        [DisplayName("菜单名称：")]
        [Required(ErrorMessage = "请填写菜单名称")]
        public string MenuName { get; set; }

        [DisplayName("菜单价格：")]
        [Required(ErrorMessage = "请填写菜单价格")]
        public decimal Price { get; set; }

        [DisplayName("是否销售：")]
        public bool IsSale { get; set; }
    }
}
