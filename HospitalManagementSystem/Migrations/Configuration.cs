namespace HospitalManagementSystem.Migrations
{
    using HospitalManagementSystem.Context;
    using HospitalManagementSystem.Models.UserAccount;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalManagementSystem.Context.HospitalManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalManagementSystem.Context.HospitalManagementSystemContext context)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            List<string> userRoles = new List<string> { "Admin", "Patient", "Doctor", "Pharmacist" };
            var checkRolesInDatabase = db.Roles.Select(a=>a.RoleName);
            if (checkRolesInDatabase.Count() != 4)
            {
                foreach (string role in userRoles)
                {
                    Role roleModel = new Role
                    {
                        RoleName = role
                    };
                    db.Roles.Add(roleModel);
                }
                db.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
