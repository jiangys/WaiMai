using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHTR.WaiMai.Contracts.Models
{
    [MetadataType(typeof(FoodMenuCategoryValidate))]
    public partial class FoodMenuCategory
    {

    }
    public class FoodMenuCategoryValidate
    {
        [DisplayName("选择餐厅：")]
        [Required(ErrorMessage = "请填写选择餐厅")]
        public string RestaurantId { get; set; }
        [DisplayName("类别名称：")]
        [Required(ErrorMessage = "请填写类别名称")]
        public string CName { get; set; }
    }
}
