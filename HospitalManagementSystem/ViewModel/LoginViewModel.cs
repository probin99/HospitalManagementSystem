using HospitalManagementSystem.Models.UserAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        public string Password { get; set; }
    }
}