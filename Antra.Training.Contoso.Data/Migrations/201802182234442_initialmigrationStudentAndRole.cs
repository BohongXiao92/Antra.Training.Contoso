namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigrationStudentAndRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        MiddleName = c.String(maxLength: 150),
                        DateofBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(maxLength: 150),
                        AddressLine1 = c.String(maxLength: 150),
                        AddressLine2 = c.String(maxLength: 150),
                        UnitOrApartmentNumber = c.String(maxLength: 50),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 50),
                        ZipCode = c.String(maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        LastLockedDateTime = c.DateTime(),
                        FailedAttempts = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Id", "dbo.People");
            DropForeignKey("dbo.People", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Student", new[] { "Id" });
            DropIndex("dbo.People", new[] { "Role_Id" });
            DropTable("dbo.Student");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
        }
    }
}
