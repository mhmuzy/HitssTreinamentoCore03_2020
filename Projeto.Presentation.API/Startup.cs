using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Presentation.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        //Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Swagger

            //configurando a documenta��o da API gerada pelo Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    { 
                        Title = "Hitss Treinamento Core 03 - 2020",
                        Version = "v1",
                        Description = "Seja Bem Vindo a �rea de Treinamento da Hitss",
                        Contact = new OpenApiContact
                        {
                            Name = "Hitss F�brica de Software - 2020",
                            Url = new Uri("http://www.cotiinformatica.com.br"),
                            Email = "mhmuzy857@gmail.com"
                        }
                    });
            });

            #endregion

            #region Inje��o de Depend�ncia

            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("HitssTreinamento")));

            services.AddTransient<IFornecedorRepository, Projeto.Infra.Data.Repositories.FornecedorRepository>();
            services.AddTransient<IProdutoRepository, Projeto.Infra.Data.Repositories.ProdutoRepository>();

            #endregion

            #region CORS

            services.AddCors(s => s.AddPolicy("DefaultPolicy",
                builder => {

                    builder.AllowAnyOrigin()

                    //qualquer cliente pode acessar a API

                    .AllowAnyMethod()   //qualquer m�todo POST, PUT, DELETE, GET

                    .AllowAnyHeader();  //qualquer cabe�alho <HEAD>


                }));

            #endregion
        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region CORS

            app.UseCors("DefaultPolicy");

            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger

            app.UseSwagger();

            app.UseSwaggerUI(s =>
                    { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Aula"); });

            #endregion
        }
    }
}
