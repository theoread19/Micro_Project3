using API.Services;
using API.Services.iplm;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using ProjectCore.Logging;
using ProjectCore.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup : BaseStartup
    {

        public IContainer ApplicationContainer { get; private set; } = null!;

        public Startup(IConfiguration configuration): base(configuration)
        {
            //Configuration = configuration;
        }

        //public IConfiguration Configuration { get; } = null!;

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            /*
                        services.Configure<EmployeeDatabaseSettings>(
                            Configuration.GetSection(nameof(EmployeeDatabaseSettings)));

                        services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
                            sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);*/
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen();


            var builder = new ContainerBuilder();
            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            base.Configure(app, env, logger);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
