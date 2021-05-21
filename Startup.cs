using Coding_Test.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Test.Interfaces;
using Coding_Test.Repositories;
using Coding_Test.Entities;
using Microsoft.AspNetCore.Identity;

namespace Coding_Test
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
            services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser,ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = false;
            });

            //allow react app
            services.AddCors(options =>
            {
                options.AddPolicy(name: "allowOrigin",
                                  build =>
                                  {
                                      build.WithOrigins(Configuration[AppConstants.WebClientUrl])
                                           .AllowAnyHeader()
                                           .AllowAnyMethod()
                                           .AllowCredentials();
                                  });
            });

            //add the jwt interface to enable injection
            var key = Configuration[AppConstants.JwtKey]; //this is the key used during the hashing 


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();

            //seed data
             HelperMethods.SeedData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LaundryApi v1"));
                app.UseDeveloperExceptionPage();
            }
            app.Use( async(context,next)=> 
            {

                await next();
            }
            );

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("allowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
