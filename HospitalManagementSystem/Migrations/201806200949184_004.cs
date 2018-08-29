namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DoctorID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Pharmacists",
                c => new
                    {
                        PharmacistID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PharmacistID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacists");
            DropTable("dbo.Patients");
            DropTable("dbo.Logins");
            DropTable("dbo.Doctors");
            DropTable("dbo.Admins");
        }
    }
}
