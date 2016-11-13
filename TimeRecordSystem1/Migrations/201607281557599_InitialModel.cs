namespace TimeRecordSystem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignProjectToUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Project_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        WorkTime = c.Double(nullable: false),
                        Comment = c.String(),
                        Status = c.Int(nullable: false),
                        Project_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TimePeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCredentialName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntries", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TimeEntries", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.AssignProjectToUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AssignProjectToUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.TimeEntries", new[] { "User_Id" });
            DropIndex("dbo.TimeEntries", new[] { "Project_Id" });
            DropIndex("dbo.AssignProjectToUsers", new[] { "User_Id" });
            DropIndex("dbo.AssignProjectToUsers", new[] { "Project_Id" });
            DropTable("dbo.UserCredentials");
            DropTable("dbo.TimePeriods");
            DropTable("dbo.TimeEntries");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.AssignProjectToUsers");
        }
    }
}
