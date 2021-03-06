namespace SkvProject.Web
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SkvProject.Data;
    using SkvProject.Data.Common;
    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models;
    using SkvProject.Data.Repositories;
    using SkvProject.Data.Seeding;
    using SkvProject.Services;
    using SkvProject.Services.Data.Forum;
    using SkvProject.Services.Data.Articles;
    using SkvProject.Services.Mapping;
    using SkvProject.Services.Messaging;
    using SkvProject.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(
                x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IDateService, DateService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IVotesService, VotesService>();
            services.AddTransient<IFavoriteService, FavoriteService>();
            services.AddTransient<ISourceService, SourceService>();
            services.AddTransient<INewsService, NewsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            "forumPost",
                            "p/{id}",
                            new { Controller = "Posts", Action = "ById" });
                        endpoints.MapControllerRoute(
                            "forumCategory",
                            "f/{category:minlength(3)}/{pageNumber?}",
                            new { Controller = "Forum", Action = "ByName" });
                        endpoints.MapControllerRoute(
                            "news",
                            "News/{id:int:min(1)}",
                            new { controller = "News", action = "ById", });
                        endpoints.MapControllerRoute(
                            "areaRoute",
                            "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute(
                            "default",
                            "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
