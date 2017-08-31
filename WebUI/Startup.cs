using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Data.Repositories;
using Core.Data.Infrastructure;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Core.Service;

namespace WebUI
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
            // UnitOfWork y DBFactory
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();

            // Repositorios
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<ILineaRepository, LineaRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            // Servicios
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<IDepositoService, DepositoService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<ILineaService, LineaService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IStockService, StockService>();


            //services.AddAutoMapper();

            //services.AddDbContext<EntitiesContext>(options => 
            //    options.UseSqlServer("server=.; database=GestionA4; Integrated Security=SSPI")
            //);

            services.AddDbContext<EntitiesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default"))
            );


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
