using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using featherink.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace featherink
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = Configuration.GetConnectionString("mySQLConnecctionString");
            services.AddControllersWithViews();

            services.AddDbContext<FeatherInkContext>(options => options.UseSqlServer
            ("Server=tcp:featherink.database.windows.net,1433;" +
            "Initial Catalog=featherinkDatabase;Persist Security Info=False;" +
            "User ID=sqladmin;Password=Admin#123;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;" +
            "Connection Timeout=30;"));

            //services.AddDbContext<FeatherInkContext>(opt => opt.UseMySql(connectionString));
            //services.AddDbContext<FeatherInkContext>(opt => opt.UseInMemoryDatabase("featherink"));
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //version EFcore 3..
            //RegisterDependencies(services);
        }

        /*
        public void RegisterDependencies(IServiceCollection service)
        {
            service.AddSingleton(new FeatherInkContext());
        }
        */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //var context = app.ApplicationServices.GetService<FeatherInkContext>();
            //AddTestData(context);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private static void AddTestData(FeatherInkContext context)
        {
            var user = new User
            {
                Id = 1,
                Role = "admin",
                Username = "admin",
                PasswordHash = "admin",
                Email = "admin@email.com",
                Picture = "adminPIC"
            };
            context.User.Add(user);

            var designer = new Designer
            {
                Id = 1,
                Description = "designer page admin",
                Rating = 10,
                UserId = 1
            };

            context.Designer.Add(designer);

            context.SaveChanges();
        }
    }
}
