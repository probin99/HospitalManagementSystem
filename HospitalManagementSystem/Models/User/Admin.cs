using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.User
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 nd 255 characters", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "User Role Required")]
        public string Role { get; set; }
    }
}