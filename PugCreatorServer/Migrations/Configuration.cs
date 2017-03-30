using System.Data.Entity.Migrations;

namespace PugCreatorServer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PugDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PugDbContext context)
        {
        }
    }
}
