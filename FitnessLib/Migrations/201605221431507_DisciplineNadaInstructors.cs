namespace FitnessLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisciplineNadaInstructors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstructorDisciplines", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.InstructorDisciplines", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.InstructorDisciplines", new[] { "Instructor_Id" });
            DropIndex("dbo.InstructorDisciplines", new[] { "Discipline_Id" });
            AddColumn("dbo.Disciplines", "Instructor_Id", c => c.Int());
            CreateIndex("dbo.Disciplines", "Instructor_Id");
            AddForeignKey("dbo.Disciplines", "Instructor_Id", "dbo.Instructors", "Id");
            DropTable("dbo.InstructorDisciplines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InstructorDisciplines",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Discipline_Id });
            
            DropForeignKey("dbo.Disciplines", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.Disciplines", new[] { "Instructor_Id" });
            DropColumn("dbo.Disciplines", "Instructor_Id");
            CreateIndex("dbo.InstructorDisciplines", "Discipline_Id");
            CreateIndex("dbo.InstructorDisciplines", "Instructor_Id");
            AddForeignKey("dbo.InstructorDisciplines", "Discipline_Id", "dbo.Disciplines", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InstructorDisciplines", "Instructor_Id", "dbo.Instructors", "Id", cascadeDelete: true);
        }
    }
}
