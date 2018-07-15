using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Admin.Models.VM
{
    public class LoginVM
    {
        [
            Required(ErrorMessage = "Kullanıcı Adı Giriniz!"),
            DisplayName("Kullanıcı Adı")
        ]
        public string Username { get; set; }

        [
            Required(ErrorMessage = "Şifre Giriniz!"),
            DisplayName("Şifre")
        ]
        public string Password { get; set; }
    }
}