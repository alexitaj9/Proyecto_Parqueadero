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
            services.AddSingleton<IRepositorioPropietario>(new RepositorioPropietario(new AppContext()));
            services.AddSingleton<IRepositorioEmpleado>(new RepositorioEmpleado(new AppContext()));
            services.AddSingleton<IRepositorioTipoVehiculo>(new RepositorioTipoVehiculo(new AppContext()));
            services.AddSingleton<IRepositorioEspacioParqueadero>(new RepositorioEspacioParqueadero(new AppContext()));
            services.AddSingleton<IRepositorioReserva>(new RepositorioReserva(new AppContext()));
            services.AddSingleton<IRepositorioRolEmpleado>(new RepositorioRolEmpleado(new AppContext()));
            services.AddSingleton<IRepositorioVehiculo>(new RepositorioVehiculo(new AppContext()));
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
