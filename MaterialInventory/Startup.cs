using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MaterialInventory.Data;
using Microsoft.EntityFrameworkCore;

namespace MaterialInventory
{
    //e8c371b9-8375-4d62-bc89-7da209b9bdf1
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Inventory Storage Microservice",
                        Description = "Storage and tracking of Inventory",
                        Version = "v1"
                    });
            });

            services.AddScoped<IManageMaterialRepo, SQLMaterialRepo>();

            // Environment Variables
            //var server = Configuration["DbServer"] ?? "Localhost";
            //var port = Configuration["DbPort"] ?? "1433";
            //var user = Configuration["DbUser"] ?? "SA";
            //var password = Configuration["DbPassowrd"] ?? "Pa$$w0d2019";
            //var database = Configuration["Database"] ?? "Material";


            //if (Environment.IsDevelopment())
            //{
            //    services.AddDbContext<MaterialContext>(opt => opt.UseSqlite(
            //    Configuration.GetConnectionString("Default"))
            //    );
            //}
            //else
            //{
            //    services.AddDbContext<MaterialContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("MaterialDbConnectionString")
            //      ));
            //}

            services.AddDbContext<MaterialContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("MaterialConnectionString")
                 ));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Storage");
            });
        }
    }
}
