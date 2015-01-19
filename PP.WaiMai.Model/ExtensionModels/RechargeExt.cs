using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model
{
    [MetadataType(typeof(RechargeValidate))]
    public partial class Recharge
    {

    }
    public class RechargeValidate
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        [RegularExpression(@"^-?[1-9]\d*$", ErrorMessage = "充值金额必须为整数")]
        public decimal RechargeAmount { get; set; }
    }
}
