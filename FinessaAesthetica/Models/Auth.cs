using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{ 
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }


}