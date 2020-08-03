using System.Collections.Generic;
using CTShopSolution.Application.Catalog.Products;
using CTShopSolution.Application.Common;
using CTShopSolution.Application.System.Users;
using CTShopSolution.Data.EF;
using CTShopSolution.Data.Entities;
using CTShopSolution.Utilities.Constants;
using CTShopSolution.ViewModels.System.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CTShopSolution.BackendApi
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
            services.AddDbContext<CtShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CtShopDbContext>()
                .AddDefaultTokenProviders();


            //Declare DI
            //
            //Addtransient moi mot lan request se tao moi voi IPublicProductService thi khoi tao PublicProductService
            //Khi Product controler dc khoi tao thi se goi contractor >> yeu cau doi tuong I PUBlic
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<IManageProductService, ManageProductService>();
            services.AddTransient<IStorageService, FileStorageService>();

           

            //Khai bao 
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            //UserController
            services.AddTransient<IUserService, UserService>();

            //

            //Fluent Validator
            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            //services.AddControllersWithViews();
            services.AddControllers().AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>()
                //fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterRequestValidator>()
                );

            //Khai bao swagger de check API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger API CTShop", Version = "v1" });


                //Config header
                //ding nghia moi khi goi truyen header
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                //moi khi goi  yeu cau truyen vao header
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = System.TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API CTShop V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
