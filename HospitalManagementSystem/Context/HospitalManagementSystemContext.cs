using HospitalManagementSystem.Models.Home;
using HospitalManagementSystem.Models.UserAccount;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Context
{
    public class HospitalManagementSystemContext:DbContext
    {
        //Models
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}