using Microsoft.EntityFrameworkCore;
using featherink.Database;

namespace featherink.Database
{
    public class FeatherInkContext : DbContext
    {
        public FeatherInkContext()
        {

        }

        public FeatherInkContext(DbContextOptions<FeatherInkContext> options) : base(options)
        {

        }

        public DbSet<Art> Art { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=featherink");
            }
        }
        */
        public DbSet<featherink.Database.Comment> Comment { get; set; }

        public DbSet<featherink.Database.Designer> Designer { get; set; }

        public DbSet<featherink.Database.Task> Task { get; set; }

        public DbSet<featherink.Database.User> User { get; set; }

    }
}
