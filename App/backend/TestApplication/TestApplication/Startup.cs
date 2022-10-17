using Authorization;
using AutoMapper;
using DL.Context;
using DL.RepositoriesImplementation;
using DL.RepositoryContracts;
using MapperProvider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PasswordManagers;
using ServiceContracts;
using Services;
using System;

namespace TestApplication
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

            services.AddControllers();
            services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
;

            //Cors
            services.AddCors(option => 
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            //Repo
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();

            //Services 
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IOptionService, OptionService>();


            //Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false; // temp
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtConfigure.Current.Issuer,

                        ValidateAudience = true,
                        ValidAudience = JwtConfigure.Current.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = JwtConfigure.Current.SymmetricSecurityKey,
                        ValidateIssuerSigningKey = true,                      
                    };
                });

            //Managers
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new DataMappingManager());
            });
            services.AddSingleton(mapperConfig.CreateMapper());

            services.AddTransient<IAuthJwtManager, AuthJwtManager>();
            services.AddTransient<IPasswordManager, PasswordManager>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestApplication", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestApplication v1"));
            }

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
