namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generateCoursesAndBindWithInstructor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseInstructors",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Instructor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Instructor_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.Instructor_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Instructor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseInstructors", "Instructor_Id", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructors", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseInstructors", new[] { "Instructor_Id" });
            DropIndex("dbo.CourseInstructors", new[] { "Course_Id" });
            DropTable("dbo.CourseInstructors");
            DropTable("dbo.Courses");
        }
    }
}
