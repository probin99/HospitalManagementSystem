using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.UserAccount
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Full Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        [DataType(DataType.PhoneNumber)]
        public int MobileNumber { get; set; }

        [Required(ErrorMessage ="Username Required")]
        [StringLength(15, ErrorMessage = "Must Be Between 5 to 15 Characters", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Must Be Between 5 and 15 Characters", MinimumLength = 5)]
        public string Password { get; set; }
        
        [Display(Name ="User Role")]
        [Required(ErrorMessage ="No Role Selected")]
        public string UserRole { get; set; }

        //One to Many relationship using EF Convention
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}