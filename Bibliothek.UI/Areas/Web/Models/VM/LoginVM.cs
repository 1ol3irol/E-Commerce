using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Web.Models.VM
{
    public class LoginVM
    {
        [
            Required(ErrorMessage = "Mail Adresi Giriniz!"),
            DisplayName("Mail Adresi")
        ]
        public string Email { get; set; }


        [
            Required(ErrorMessage = "Şifre Giriniz!"),
            DisplayName("Şifre")
        ]
        public string Password { get; set; }
    }
}