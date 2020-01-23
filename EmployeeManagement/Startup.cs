using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;// { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               /* DeveloperExceptionPageOptions developerexceptionoption = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 10
                };*/
                
                app.UseDeveloperExceptionPage();
            }
            /*DefaultFilesOptions defaultfileoption = new DefaultFilesOptions();
            defaultfileoption.DefaultFileNames.Clear();
            defaultfileoption.DefaultFileNames.Add("foo.html");*/
            //app.UseDefaultFiles(defaultfileoption); //  If ur using default/index, u have to specfiy the UseDefaultFiles() middleware
            app.UseStaticFiles(); // If your using static files, you have to specfiy the USEStaticFiles() middleware
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routs=> {
                routs.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            /*FileServerOptions fileserveroption = new FileServerOptions();
            fileserveroption.DefaultFilesOptions.DefaultFileNames.Clear();
            fileserveroption.DefaultFilesOptions.DefaultFileNames.Add("foo.html");*/
            //app.UseFileServer();
           

            /*else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });*/
        }
    }
}
