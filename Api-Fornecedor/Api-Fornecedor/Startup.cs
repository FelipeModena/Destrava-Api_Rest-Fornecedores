using Api_Empresas.Business.BusinessImplementation;
using Api_Fornecedor.Business.BusinessImplementation;
using Api_Fornecedor.BusinessImplementation;
using Api_Fornecedor.Repository;
using Api_Fornecedor.Repository.RepositoryImplementation;
using ApiRestComASPNet.Model.Context;
using ApiRestComASPNet.Repository.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor
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
            services.AddCors();
            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Fornecedor", Version = "v1" });
            });


            #region Regiao de conexao com banco de dados MySql
            var MySqlConnectionString = Configuration.GetConnectionString("MySQLString");
            services.AddDbContext<MySqlContext>(optionsAction => optionsAction.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString)));
            #endregion

            #region Injecao de dependencia

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEmpresaBusiness, EmpresaBusiness>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();


            services.AddScoped<IFornecedorBusiness, FornecedorBusiness>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            #endregion



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_Fornecedor v1"));
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
