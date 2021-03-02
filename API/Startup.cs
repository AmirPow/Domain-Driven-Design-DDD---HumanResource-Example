using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using HR.Framework.AssemblyHelper;
using HR.Framework.Core.DependencyInjection;
using HR.Framework.Core.Persistence;
using HR.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API
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
            var assemblyDiscovery = new AssemblyDiscovery("HR*.dll");
            var registrars = assemblyDiscovery.DiscoverInstance<IRegistrar>("HR").ToList();
            foreach (var registrar in registrars)
            {
                registrar.Register(services, assemblyDiscovery); ;
            }
            services.AddDbContext<IDbContext, HRDbContext>(op =>
            {
                op.UseSqlServer("Data Source=localhost;Initial Catalog=HR;Integrated Security=True");

            });
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Of HR");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
