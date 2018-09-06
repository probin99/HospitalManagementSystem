using HospitalManagementSystem.Models.UserAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.ViewModel
{
    public class RegisterViewModel
    {
        public UserAccount User { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [StringLength(255, ErrorMessage = "Must be between 5 nd 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and Confirm Password fields do not match")]
        public string ConfirmPassword { get; set; }
    }
}