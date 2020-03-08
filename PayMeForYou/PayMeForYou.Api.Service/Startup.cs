using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayMeForYou.Service.Repositories;
using PayMeForYou.Service.Repositories.Interface;
using PayMeForYou.Service.Services;
using PayMeForYou.Service.Services.Interface;

namespace PayMeForYou.Api.Service
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
            services.AddControllers();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IRoleService, RoleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllers();
                //    endpoints.MapControllerRoute(
                //    name: "areaRoute",
                //    pattern: "{area:exists}/{controller}/{action}",
                //defaults: new { action = "Index" });



                //endpoints.MapControllerRoute(
                //    name: "api",
                //    pattern: "{controller}/{id?}");
            });

            //custom middle ware sample
            //app.Use((context, next) =>
            //{
            //    var endpointFeature = context.Features[typeof(Microsoft.AspNetCore.Http.Features.IEndpointFeature)]
            //                                           as Microsoft.AspNetCore.Http.Features.IEndpointFeature;

            //    Microsoft.AspNetCore.Http.Endpoint endpoint = endpointFeature?.Endpoint;

            //    //Note: endpoint will be null, if there was no
            //    //route match found for the request by the endpoint route resolver middleware
            //    if (endpoint != null)
            //    {
            //        var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern
            //                                                                                   ?.RawText;

            //        Console.WriteLine("Name: " + endpoint.DisplayName);
            //        Console.WriteLine($"Route Pattern: {routePattern}");
            //        Console.WriteLine("Metadata Types: " + string.Join(", ", endpoint.Metadata));
            //    }
            //    return next();
            //});
        }
    }
}
