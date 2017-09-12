using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_v5.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}