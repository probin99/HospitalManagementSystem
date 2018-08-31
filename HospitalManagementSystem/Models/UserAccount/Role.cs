using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.UserAccount
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Role Name Required")]
        public string RoleName { get; set; }

        //One to Many relationship using EF Convention
        public ICollection<UserAccount> User { get; set; }
    }
}