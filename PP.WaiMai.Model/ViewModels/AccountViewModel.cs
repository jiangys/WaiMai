using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "忘记填写姓名了哦")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "忘记填写密码了哦")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "真实姓名")]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符", MinimumLength = 2)]
        [Required(ErrorMessage = "忘记填写姓名了哦")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "忘记填写密码了哦")]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "IP地址")]
        public string IPAddress { get; set; }


        [Display(Name = "所属部门")]
        [Required(ErrorMessage = "请选择所属部门")]
        public int DepartmentType { get; set; }
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }
}
