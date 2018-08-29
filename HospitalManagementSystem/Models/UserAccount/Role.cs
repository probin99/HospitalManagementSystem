﻿using System;
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

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Select User Role")]
        public string RoleName { get; set; }

        //One to Many relationship using EF Convention
        public ICollection<User> User { get; set; }
    }
}