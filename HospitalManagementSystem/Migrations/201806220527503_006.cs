namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Admins", "Role", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "Password", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Doctors", "Role", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "Password", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Patients", "Role", c => c.String(nullable: false));
            AddColumn("dbo.Pharmacists", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Pharmacists", "Password", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Pharmacists", "Role", c => c.String(nullable: false));
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.Pharmacists", "Role");
            DropColumn("dbo.Pharmacists", "Password");
            DropColumn("dbo.Pharmacists", "Email");
            DropColumn("dbo.Patients", "Role");
            DropColumn("dbo.Patients", "Password");
            DropColumn("dbo.Patients", "Email");
            DropColumn("dbo.Doctors", "Role");
            DropColumn("dbo.Doctors", "Password");
            DropColumn("dbo.Doctors", "Email");
            DropColumn("dbo.Admins", "Role");
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Admins", "Email");
        }
    }
}
