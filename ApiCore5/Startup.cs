using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Business;
using ApiCore5.Business.Implementations;
using ApiCore5.Repository;
using ApiCore5.Repository.Implementations;
using ApiCore5.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCore5
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

            var configurations = Configuration["MySqlConnection:MySqlConnectionString"];

            // passo a implementação
            services.AddDbContext<MySqlContext>(options => options.UseMySql(configurations));

            services.AddApiVersioning();


            // serviços de injeção de dependencias
            //Abstração e implementação do componente que controlará as regras de negocio da aplicação
            services.AddScoped<IPersonBusiness, PersonBusiness>();

            //Abstração e implementação do componente que acessará o banco de dados
            services.AddScoped<IPersonRepository, PersonRepository>();
          
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
                endpoints.MapControllers();
            });
        }
    }
}
