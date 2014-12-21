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
        [Required]
        public int FoodMenuID { get; set; }

        [Required]
        public string TotalPrice { get; set; }
    }
}
