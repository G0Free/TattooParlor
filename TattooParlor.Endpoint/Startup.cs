using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Data;
using TattooParlor.Logic;
using TattooParlor.Repository;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace TattooParlor.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); //enable controllers

            //IoC
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITattooLogic, TattooLogic>();
            services.AddTransient<IJobsDoneLogic, JobsDoneLogic>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ITattooRepository, TattooRepository>();
            services.AddTransient<IJobsDoneRepository, JobsDoneRepository>();

            services.AddTransient<DbContext, CompanyContext>(); //.AddTransient
                                                    //.AddSingleton

            var configSection = Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection");

            var settings = new DatabaseSettings();
            settings.ConnectionString = configSection.Value;
            configSection.Bind(settings);
            
            services.AddSingleton(settings);
            ;
            services.AddDbContext<CompanyContext>( opt => opt.UseSqlServer(settings.ConnectionString)); //settings.ConnectionString
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapControllers();
            });
        }
    }
}
