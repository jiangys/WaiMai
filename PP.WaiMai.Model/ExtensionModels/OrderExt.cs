using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model
{
    [MetadataType(typeof(OrderValidate))]
    public partial class Order
    {

    }
    public class OrderValidate
    {
        [DisplayName("昵称：")]
        [Required(ErrorMessage = "请填写你的昵称")]
        public string NickName { get; set; }
    }
}
