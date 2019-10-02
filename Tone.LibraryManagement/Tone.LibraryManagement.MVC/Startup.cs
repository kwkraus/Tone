using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tone.LibraryManagement.Azure.Services.Extensions;
using Tone.LibraryManagement.Data.Contexts;

namespace Tone.LibraryManagement.MVC
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
            services.AddControllersWithViews();

            services.AddDbContext<LibraryMgmtContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
            );

            services.AddAzureStorageService(Configuration.GetSection("AzureStorage"));

            // here's an example of how to register the AWSStorageService using options and extensions
            //
            //Method #1 - passing in IConfigurationSection
            //services.AddAWSStorageService(Configuration.GetSection("AWSStorage"));
            //
            //Method #2 - Using a delegate function to define individual values.
            //services.AddAWSStorageService(options =>
            //    {
            //        options.ServiceUrl = Configuration["AWSStorage:ServiceUrl"];
            //        options.BucketName = Configuration["AWSStorage:BucketName"];
            //    }
            //);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
