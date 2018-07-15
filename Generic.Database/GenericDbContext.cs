using Generic.Database.Poco;
using System.Data.Entity;

namespace Generic.Database
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {
            System.Data.Entity.Database.SetInitializer<GenericDbContext>(new DropCreateDatabaseIfModelChanges<GenericDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
