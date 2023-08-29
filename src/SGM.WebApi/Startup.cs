using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using SGM.ApplicationServices.AutoMapper;
using SGM.CrossCutting;
using SGM.Domain.ValueObjects;
using System;

namespace SGM.WebApi
{
    public class Startup
    {
        const string DEFAULT_LOG_DIRECTORY = "C:/Logs/SGM.WebApi";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton(Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>());
            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());
            var filePath = Configuration.GetSection("Log:Path") is null ? DEFAULT_LOG_DIRECTORY : Configuration.GetSection("Log:Path").Value;

            services.AddSingleton<ILogger, Serilog.Core.Logger>(x =>
            {
                var logger = new LoggerConfiguration()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

                return logger;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "7.3",
                    Title = "Exposição do banco de dados das aplicações do SGM",
                    Description = "Essa API faz todos os cadastros pertinentes ao sistema SGM (Sistema Gerenciamento Mecânica) facilitando a utilização para qualquer tipo de plataforma",
                    TermsOfService = new Uri("http://arielgiacomini.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ariel Giacomini da Silva",
                        Email = "arieltecnologia@outlook.com",
                        Url = new Uri("http://arielgiacomini.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Não há licença",
                        Url = new Uri("http://arielgiacomini.com.br")
                    }
                });
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "SGM");
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();
            app.UseMvc();
        }

        private void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}