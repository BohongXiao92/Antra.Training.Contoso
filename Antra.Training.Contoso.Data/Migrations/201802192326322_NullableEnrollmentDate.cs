namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableEnrollmentDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
    }
}
