using CaloriePunch.Data;
using CaloriePunch.Data.Settings;
using CaloriePunch.Data.Settings.Interfaces;
using CaloriePunch.Services;
using CaloriePunch.Services.Interfaces;
using Identity;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriePunch.API
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
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ICalorieService, CalorieService>();

            AddAppCorsPolicies(services);
            Settings.Current.AddAuthScheme(services);

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson();
            services.AddAuthorization();
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

            app.UseCors("AllowedOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddAppCorsPolicies(IServiceCollection services)
        {
            var origins = Configuration.GetSection("AllowedOrigins").Value.Split(';');
            services.AddCors(options =>
            {

                options.AddPolicy(name: "AllowedOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins(origins);
                                      //builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();

                                  });
            });


        }

    }
}
