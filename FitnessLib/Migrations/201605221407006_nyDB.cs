namespace FitnessLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nyDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FitnessClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instructor_Id = c.Int(),
                        Discipline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Discipline_Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Adress = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Gyms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstructorDisciplines",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Discipline_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Discipline_Id);
            
            CreateTable(
                "dbo.UserFitnessClasses",
                c => new
                    {
                        User_UserId = c.String(nullable: false, maxLength: 128),
                        FitnessClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.FitnessClass_Id })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.FitnessClasses", t => t.FitnessClass_Id, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.FitnessClass_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFitnessClasses", "FitnessClass_Id", "dbo.FitnessClasses");
            DropForeignKey("dbo.UserFitnessClasses", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.FitnessClasses", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.InstructorDisciplines", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.InstructorDisciplines", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.FitnessClasses", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.UserFitnessClasses", new[] { "FitnessClass_Id" });
            DropIndex("dbo.UserFitnessClasses", new[] { "User_UserId" });
            DropIndex("dbo.InstructorDisciplines", new[] { "Discipline_Id" });
            DropIndex("dbo.InstructorDisciplines", new[] { "Instructor_Id" });
            DropIndex("dbo.FitnessClasses", new[] { "Discipline_Id" });
            DropIndex("dbo.FitnessClasses", new[] { "Instructor_Id" });
            DropTable("dbo.UserFitnessClasses");
            DropTable("dbo.InstructorDisciplines");
            DropTable("dbo.Gyms");
            DropTable("dbo.Users");
            DropTable("dbo.Instructors");
            DropTable("dbo.Disciplines");
            DropTable("dbo.FitnessClasses");
        }
    }
}
