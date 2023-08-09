using HomeBankingMindhub.Controllers;
using HomeBankingMindhub.Models;
using HomeBankingMindhub.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace HomeBankingMindhub
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
            //Agregamos el contexto de la base de datos
            services.AddDbContext<HomeBankingContext>(opt=>opt.UseSqlServer(Configuration.GetConnectionString("HomeBankingConnection")));
            //Agregamos el repositorio de clientes
            services.AddScoped<IClientRepository, ClientRepository>();
            //Agregamos el repositorio de cuentas
            services.AddScoped<IAccountRepository, AccountRepository>();
            //Agregamos el repositorio de tarjetas
            services.AddScoped<ICardRepository, CardRepository>();
            //Agregamos el controlador de cuentas
            services.AddScoped<AccountsController>();
            //Agregamos el controlador de tarjetas
            services.AddScoped<CardsController>();

            //Agregamos los controladores y configuramos el serializador para que no se rompa con las referencias circulares
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            //Agregamos el servicio de autenticacion por cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                //Login path, en la guia dice new PathString("/index.html"), volver a esta configuracion si la actual no funciona
                option.LoginPath = "/index.html";
            });
            //Agregamos el servicio de autorizacion
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientOnly", policy => policy.RequireClaim("Client"));
            });
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            //Agregamos el middleware de autenticacion
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //Agregamos los endpoints de los controladores
                endpoints.MapControllers();
            });
        }
    }
}
