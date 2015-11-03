namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(nullable: false),
                        Tasks_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Tasks_Id)
                .Index(t => t.Tasks_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussions", "Tasks_Id", "dbo.Tasks");
            DropIndex("dbo.Discussions", new[] { "Tasks_Id" });
            DropTable("dbo.Discussions");
        }
    }
}
