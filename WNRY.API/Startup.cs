﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Text;
using WNRY.API.Utils;
using WNRY.Core.Data;
using WNRY.Models.IdentityModels;
using WNRY.Services.Identity;
using WNRY.Services.Utils;
using WNRY.Core.Data.Interfaces;
using WNRY.Services.Interfaces;
using WNRY.Services;
using WNRY.Utils.MailKit;
using WNRY.Utils.MailKit.Models;

namespace WNRY.API
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add framework services.
            services.AddDbContext<WnryDbContext>(options =>
                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                            sqlServerOptionsAction => sqlServerOptionsAction.MigrationsAssembly("WNRY.Migrations")));

            // Data repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(IRegionRepository), typeof(RegionsRepository));
            services.AddScoped(typeof(IContactDetailsRepository), typeof(ContactDetailsRepository));
            services.AddScoped(typeof(IAddressesRepository), typeof(AddressesRepository));
            services.AddScoped(typeof(IProductsRepository), typeof(ProductsRepository));

            // Application  Services
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IContactDetailsService, ContactDetailsService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IPlaceOrderService, PlaceOrderService>();
            services.AddTransient<IProductService, ProductService>();


            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton<IMailer, WnryMailService>();

            // Register the ConfigurationBuilder instance of FacebookAuthSettings
            //  services.Configure<FacebookAuthSettings>(Configuration.GetSection(nameof(FacebookAuthSettings)));

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            // add identity
            var builder = services.AddIdentityCore<AppUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<WnryDbContext>().AddDefaultTokenProviders();

            services.AddCors(options => options.AddPolicy("AllowAll", p =>
                                    p.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));
            //  services.AddAutoMapper();
            services.AddMvc(); // .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                var error = context.Features.Get<IExceptionHandlerFeature>();
                                if (error != null)
                                {
                                    context.Response.AddApplicationError(error.Error.Message);
                                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                }
                            });
                });

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                // cfg.CreateMap<AppUser, Models.ViewModels.CustomerVM>();
                cfg.CreateMap<Models.CommonModels.Region, Models.ViewModels.RegionVM>();
            });
        }
    }
}