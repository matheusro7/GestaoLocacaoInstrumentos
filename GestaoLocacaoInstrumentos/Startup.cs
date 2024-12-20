﻿using GestaoLocacaoInstrumentos.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GestaoLocacaoInstrumentos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configuração dos serviços do aplicativo
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura o banco de dados
            //services.AddDbContext<LocadoraContext>(options =>
            //options.UseInMemoryDatabase("GestaoLocacaoInstrumentos"));

              //  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Adiciona o suporte ao Razor Pages e MVC
            services.AddControllersWithViews();

            // Configuração de dependências adicionais (opcional)
            // Exemplo: Autenticação, Cache, etc.
        }

        // Configuração do pipeline de requisições HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

