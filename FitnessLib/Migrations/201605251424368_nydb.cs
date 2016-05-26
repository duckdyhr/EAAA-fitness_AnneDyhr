namespace FitnessLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nydb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FitnessClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(precision: 7, storeType: "datetime2"),
                        Duration = c.Int(nullable: false),
                        Discipline_Id = c.Int(),
                        Instructor_InstructorId = c.Int(),
                        Gym_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId)
                .ForeignKey("dbo.Gyms", t => t.Gym_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Instructor_InstructorId)
                .Index(t => t.Gym_Id);
            
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
                        InstructorId = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Adress = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InstructorId);
            
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
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.InstructorDisciplines",
                c => new
                    {
                        Instructor_InstructorId = c.Int(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_InstructorId, t.Discipline_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .Index(t => t.Instructor_InstructorId)
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
            DropForeignKey("dbo.FitnessClasses", "Gym_Id", "dbo.Gyms");
            DropForeignKey("dbo.InstructorDisciplines", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.InstructorDisciplines", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.FitnessClasses", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.FitnessClasses", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.UserFitnessClasses", new[] { "FitnessClass_Id" });
            DropIndex("dbo.UserFitnessClasses", new[] { "User_UserId" });
            DropIndex("dbo.InstructorDisciplines", new[] { "Discipline_Id" });
            DropIndex("dbo.InstructorDisciplines", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.FitnessClasses", new[] { "Gym_Id" });
            DropIndex("dbo.FitnessClasses", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.FitnessClasses", new[] { "Discipline_Id" });
            DropTable("dbo.UserFitnessClasses");
            DropTable("dbo.InstructorDisciplines");
            DropTable("dbo.Users");
            DropTable("dbo.Gyms");
            DropTable("dbo.Instructors");
            DropTable("dbo.Disciplines");
            DropTable("dbo.FitnessClasses");
        }
    }
}
