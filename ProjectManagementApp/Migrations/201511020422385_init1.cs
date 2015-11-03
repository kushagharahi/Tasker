namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discussions", "Tasks_Id", "dbo.Tasks");
            DropIndex("dbo.Discussions", new[] { "Tasks_Id" });
            AddColumn("dbo.Discussions", "Project_Id", c => c.Guid());
            CreateIndex("dbo.Discussions", "Project_Id");
            AddForeignKey("dbo.Discussions", "Project_Id", "dbo.Projects", "Id");
            DropColumn("dbo.Discussions", "Tasks_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discussions", "Tasks_Id", c => c.Guid());
            DropForeignKey("dbo.Discussions", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Discussions", new[] { "Project_Id" });
            DropColumn("dbo.Discussions", "Project_Id");
            CreateIndex("dbo.Discussions", "Tasks_Id");
            AddForeignKey("dbo.Discussions", "Tasks_Id", "dbo.Tasks", "Id");
        }
    }
}
