using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model
{
    [MetadataType(typeof(RestaurantValidate))]
    public partial class Restaurant
    {

    }
    public class RestaurantValidate
    {
        [DisplayName("餐厅名称：")]
        [Required(ErrorMessage = "请填写餐厅名称")]
        public string RestaurantName { get; set; }

        [DisplayName("订餐电话：")]
        [Required(ErrorMessage = "请填写订餐电话")]
        public string TakeoutPhone { get; set; }

        [DisplayName("起送份数：")]
        [Required(ErrorMessage = "请填写起送份数")]
        public int SendOutCount { get; set; }

        [DisplayName("餐厅描述：")]
        public int Description { get; set; }

        [DisplayName("是否启用：")]
        public bool IsEnable { get; set; }
    }
}
