using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnstrumanSatis_MVC_Project.Models
{
    public class UserLogin
    {

        [Display(Name = "Kullanıcı Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Kullanıcı Adı Gerekli")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Şifre Gerekli")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
       public bool RememberMe { get; set; }



    }
}