using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProjectHamiltonService.Game;
using ProjectHamiltonService.Models;
using Microsoft.AspNetCore.StaticFiles;

namespace ProjectHamiltonService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameContext>(opt => 
                opt.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSignalR();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            StaticFileOptions option = new StaticFileOptions();
            FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider)option.ContentTypeProvider ??
            new FileExtensionContentTypeProvider();

            contentTypeProvider.Mappings.Add(".mem", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".data", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".memgz", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".datagz", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".unity3dgz", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".unityweb", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".jsgz", "application/x-javascript; charset=UTF-8");
            option.ContentTypeProvider = contentTypeProvider;
            app.UseStaticFiles(option);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Teacher}/{action=Index}/{id?}");
                endpoints.MapHub<ServerHub>("/gameapi");
            });
        }
    }
}
