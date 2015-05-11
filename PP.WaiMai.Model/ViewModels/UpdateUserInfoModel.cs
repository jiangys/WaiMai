using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    public class UpdateUserInfoModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "忘记填写姓名了哦")]
        public string UserName { get; set; }

        [Display(Name = "所属部门")]
        [Required(ErrorMessage = "请选择所属部门")]
        public int DepartmentType { get; set; }
    }
}
