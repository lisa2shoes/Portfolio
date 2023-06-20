using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle;
using Microsoft.OpenApi.Models;

namespace hw13_1_asp
{
    public class Startup
    {
        public Startup(IConfiguration configuration) // что значат эти аргументы метода? и что это за метод?
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // что значат эти аргументы метода?
        {
            services.AddSwaggerGen( options =>
            options.SwaggerDoc ("V1", new OpenApiInfo
            {
                Version = "My Api V1",
                Title = "My Api",
                Description = "My Api",
                TermsOfService = new Uri("http://www.reshalka_uravnenii.com"),
                Contact = new OpenApiContact
                {
                    Name = "Sharath C V",
                    Email = "me@sharathcv.com",
                    Url = new Uri("http://www.reshalka_uravnenii.com")
                }
            }) 
            );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // что значат эти аргументы метода?
        {
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            app.UseSwagger(); // builder не стала использовать, потому что не было в инструкции, да и WebApplication.CreateBuilder() нет в 5.0
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "My Api V1"); // этого не было в коде с занятия, и я опять же могу только догадываться, что оно делает,
                                                                                  // и почему оно было не нужно там, но нужно здесь
            });

        }
    }
}
