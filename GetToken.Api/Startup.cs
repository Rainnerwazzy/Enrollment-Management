using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;

namespace GetToken.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddServiceDiscovery(o => o.UseEureka());
            //IdentityModelEventSource.ShowPII = true;
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
              .AddCookie("Cookies")
              .AddOpenIdConnect("oidc", options =>
              {
                  options.Authority = Configuration["Auth:Authority"];
                  //options.GetClaimsFromUserInfoEndpoint = true;
                  options.ClientId = "geek_universidade";
                  options.ClientSecret = "my_super_secret";
                  options.ResponseType = "code";
                  //options.ClaimActions.MapJsonKey("role", "role", "role");
                  //options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                  //options.TokenValidationParameters.NameClaimType = "name";
                  //options.TokenValidationParameters.RoleClaimType = "role";
                  options.Scope.Add("geek_universidade");
                  options.Scope.Add("offline_access");
                  options.SaveTokens = true;
              });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "geek_universidade");
            //    });
            //});

            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = Configuration["Auth:Authority"];
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "GetToken.Api", Version = "v1" });                
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                               .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GetToken.Api v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
