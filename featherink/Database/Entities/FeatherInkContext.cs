using Microsoft.EntityFrameworkCore;
using featherink.Database;
using Microsoft.Extensions.Configuration;

namespace featherink.Database.Entities
{
    public class FeatherInkContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public FeatherInkContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FeatherInkContext()
        {
        }

        public FeatherInkContext(DbContextOptions<FeatherInkContext> options) : base(options)
        {

        }

        public DbSet<Art> Art { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
            ("Server=tcp:featherinkserver.database.windows.net,1433;" +
            "Initial Catalog=featherink_db;" +
            "Persist Security Info=False;" +
            "User ID=vgrmm;" +
            "Password=2privatestaticBool;" +
            "MultipleActiveResultSets=False;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;");
                //optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=featherink");
            }
        }
        
        public DbSet<featherink.Database.Entities.Comment> Comment { get; set; }

        public DbSet<featherink.Database.Entities.Designer> Designer { get; set; }

        public DbSet<featherink.Database.Entities.Task> Task { get; set; }

        public DbSet<featherink.Database.Entities.User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion","2.2.4-servicing-10062");
            modelBuilder.Entity<User>(entity =>
            {

            });
        }
    }
}
