using System.Data.Entity;
using PugCreatorServer.Models;

namespace PugCreatorServer
{
    public class PugDbContext : DbContext
    {
        public PugDbContext() : base("name=PugDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Pug> Pugs { get; set; }
    }
}
