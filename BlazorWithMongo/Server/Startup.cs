using BlazorWithMongo.Server.DataAccess;
using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Globalization;

namespace BlazorWithMongo.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IEmployee, EmployeeDataAccessLayer>();
            services.AddTransient<ITool, ToolDataAccessLayer>();
            services.AddSingleton(options => options.GetRequiredService<IOptions<EmployeeDBContext>>().Value);
            services.AddSingleton(options => options.GetRequiredService<IOptions<ToolDBContext>>().Value);
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ3NTMxQDMxMzgyZTMxMmUzMFdNZk5hbEVhVStlWlJjeVNORDlWWHJSWXpEZnN4Nmhvd3JsVUtDaktXWUU9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Program>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Program>("index.html");
            });
        }
    }
}
