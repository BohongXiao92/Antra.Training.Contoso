namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generateCoursesAndBindWithInstructor2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseInstructors", newName: "InstructorCourses");
            DropPrimaryKey("dbo.InstructorCourses");
            AddPrimaryKey("dbo.InstructorCourses", new[] { "Instructor_Id", "Course_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.InstructorCourses");
            AddPrimaryKey("dbo.InstructorCourses", new[] { "Course_Id", "Instructor_Id" });
            RenameTable(name: "dbo.InstructorCourses", newName: "CourseInstructors");
        }
    }
}
