namespace LogingWithEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserVS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Loogin = c.String(),
                        Password = c.String(),
                        Department_Id = c.Int(),
                        Details_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.UserDetails", t => t.Details_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Details_Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUserVS",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        UserVS_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.UserVS_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserVS", t => t.UserVS_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.UserVS_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUserVS", "UserVS_Id", "dbo.UserVS");
            DropForeignKey("dbo.RoleUserVS", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserVS", "Details_Id", "dbo.UserDetails");
            DropForeignKey("dbo.UserVS", "Department_Id", "dbo.Departments");
            DropIndex("dbo.RoleUserVS", new[] { "UserVS_Id" });
            DropIndex("dbo.RoleUserVS", new[] { "Role_Id" });
            DropIndex("dbo.UserVS", new[] { "Details_Id" });
            DropIndex("dbo.UserVS", new[] { "Department_Id" });
            DropTable("dbo.RoleUserVS");
            DropTable("dbo.Roles");
            DropTable("dbo.UserDetails");
            DropTable("dbo.UserVS");
            DropTable("dbo.Departments");
        }
    }
}
