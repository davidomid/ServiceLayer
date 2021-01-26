using System.Collections.Generic;
using ExampleServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer;
using ServiceLayer.Core;
using ServiceLayer.Core.Converters;
using ServiceLayer.Core.Internal.Converters;

namespace ExampleAspNetCoreWebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IDocumentStorageService>(new DocumentStorageService(new AuthService()));
            ServiceLayerConfig.Plugins.Install(new AspNetCorePlugin(new AspNetCorePluginSettings
            {
                ResultTypeConverters = new ActionResultConverterCollection(new List<IActionResultConverter>())
            }));
            ServiceLayerConfig.Plugins.Install(new DocumentServicePlugin());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
