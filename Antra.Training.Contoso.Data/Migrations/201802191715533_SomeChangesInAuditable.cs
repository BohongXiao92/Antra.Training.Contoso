namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesInAuditable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Courses", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Enrollments", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.People", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.People", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.OfficeAssignments", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Departments", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Departments", "CreatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.OfficeAssignments", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.People", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.People", "CreatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Enrollments", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Courses", "UpdatedBy", c => c.String(maxLength: 20));
            AlterColumn("dbo.Courses", "CreatedBy", c => c.String(maxLength: 20));
        }
    }
}
