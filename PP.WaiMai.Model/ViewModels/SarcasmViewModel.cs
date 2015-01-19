using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
   public class SarcasmViewModel
    {
       public int Type { get; set; }

      [Required(ErrorMessage = "请填写吐槽内容")]
       public string Content { get; set; }
    }
}
