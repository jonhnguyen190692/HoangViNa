using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_v5.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Yêu cầu đăng nhập")]
        public string UserName { get; set; }

        [StringLength(20,MinimumLength = 6,ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]

        public string Password { get; set; }
        
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage = "Xác nhận mật khẩu không chính xác.")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        [Display(Name = "Họ tên")]

        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]

        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập Email")]

        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Điện thoại")]

        public string Phone { get; set; }
        [Display(Name = "Tỉnh/Thành phố")]

        public int ProvinceID { get; set; }
        [Display(Name = "Quận/Huyện")]

        public int DistrictID { get; set; }
    }
}