using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Newtonsoft.Json.Linq;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;
using Ocelot.Provider.Polly;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Enrollment.Management.WebAPI
{
    public class Startup
    {
        private readonly IConfigurationRoot Configuration;

        public Startup(IWebHostEnvironment env)
        {

            var ocelotJson = new JObject();
            foreach (var jsonFilename in Directory.EnumerateFiles("Routes", "ocelot.*.json", SearchOption.AllDirectories))
            {
                using (StreamReader fi = File.OpenText(jsonFilename))
                {
                    var json = JObject.Parse(fi.ReadToEnd());
                    ocelotJson.Merge(json, new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Union
                    });
                }
            }

            File.WriteAllText("ocelot.json", ocelotJson.ToString());

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"ocelot.{env.EnvironmentName}.json",optional: true, reloadOnChange: true).AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(Configuration).AddEureka().AddPolly();
            services.AddSwaggerForOcelot(Configuration);          
            services.AddServiceDiscovery(o => o.UseEureka());
            services.AddControllers();
            services.AddSwaggerGen();           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
               // app.UseSwaggerUI();
            }

           // app.UseOcelot();
            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseSwaggerForOcelotUI(options =>
            {
                options.PathToSwaggerGenerator = "/swagger/docs";

            }).UseOcelot().Wait();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
