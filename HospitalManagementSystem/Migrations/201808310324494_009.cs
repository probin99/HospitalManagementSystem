namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _009 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserAccounts");
            AddColumn("dbo.UserAccounts", "UserName", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.UserAccounts", "UserRole", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "UserRole");
            DropColumn("dbo.UserAccounts", "UserName");
            RenameTable(name: "dbo.UserAccounts", newName: "Users");
        }
    }
}
