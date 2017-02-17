using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Users :RecordInformation
    {
        [Key]
        public int UsersId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(24, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Employee Number")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Middlename")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        private string _fullname;

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}",
                                     this.FirstName,
                                     this.MiddleName,
                                     this.LastName);
            }
            private set
            {
                _fullname = string.Format("{0} {1} {2}",
                                   this.FirstName,
                                   this.MiddleName,
                                   this.LastName);
            }
        }      
    }
}