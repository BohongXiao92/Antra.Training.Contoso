namespace Antra.Training.Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generateInstructor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RolePersons", newName: "PersonRoles");
            DropPrimaryKey("dbo.PersonRoles");
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            AddPrimaryKey("dbo.PersonRoles", new[] { "Person_Id", "Role_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructor", "Id", "dbo.People");
            DropIndex("dbo.Instructor", new[] { "Id" });
            DropPrimaryKey("dbo.PersonRoles");
            DropTable("dbo.Instructor");
            AddPrimaryKey("dbo.PersonRoles", new[] { "Role_Id", "Person_Id" });
            RenameTable(name: "dbo.PersonRoles", newName: "RolePersons");
        }
    }
}
