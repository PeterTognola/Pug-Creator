using System.Data.Entity.Migrations;

namespace PugCreatorServer.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Pugs",
                    c => new
                    {
                        Id = c.Guid(false),
                        Name = c.String(),
                        Coat_Id = c.Guid()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PugCoat", t => t.Coat_Id)
                .Index(t => t.Coat_Id);

            CreateTable(
                    "dbo.PugCoat",
                    c => new
                    {
                        Id = c.Guid(false),
                        ColourCode = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Pugs", "Coat_Id", "dbo.PugCoat");
            DropIndex("dbo.Pugs", new[] {"Coat_Id"});
            DropTable("dbo.PugCoat");
            DropTable("dbo.Pugs");
        }
    }
}
