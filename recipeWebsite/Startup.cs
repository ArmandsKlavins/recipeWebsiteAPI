using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using recipeWebsite.Models;
using Microsoft.EntityFrameworkCore;
using recipeWebsite.services;
using recipeWebsite.Configs;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace recipeWebsite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings();
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            
            services.AddMvc()

                  .AddJsonOptions(x =>
                  {
                      x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                      x.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                      x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                      x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  }); ;
            var connection = @"Server=(localdb)\MSSQLLocalDB;Database=Recipe_Website;Trusted_Connection=True;";
            
            services.AddDbContext<WebsiteContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, WebsiteContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder =>
            builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyOrigin()
                            .Build());
            app.UseMvc();
            DbInitializer.Initialize(context);
        }
    }
}
