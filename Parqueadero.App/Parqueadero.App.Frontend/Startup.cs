using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parqueadero.App.Persistencia;
using AppContext = Parqueadero.App.Persistencia.AppContext;

namespace Parqueadero.App.Frontend
{
    public class Startup
    {
        //Declarar contexto
        Persistencia.AppContext _context = new Persistencia.AppContext();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            //Relacion con los repositorios
            services.AddSingleton<IRepositorioPropietario>(new RepositorioPropietario(_context));
            services.AddSingleton<IRepositorioEmpleado>(new RepositorioEmpleado(_context));
            services.AddSingleton<IRepositorioTipoVehiculo>(new RepositorioTipoVehiculo(_context));
            services.AddSingleton<IRepositorioEspacioParqueadero>(new RepositorioEspacioParqueadero(_context));
            services.AddSingleton<IRepositorioReserva>(new RepositorioReserva(_context));
            services.AddSingleton<IRepositorioRolEmpleado>(new RepositorioRolEmpleado(_context));
            services.AddSingleton<IRepositorioVehiculo>(new RepositorioVehiculo(_context));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
