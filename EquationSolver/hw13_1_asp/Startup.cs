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
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {

            app.UseSwagger(); 
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "My Api V1"); 
                                                                                  
            });

        }
    }
}
