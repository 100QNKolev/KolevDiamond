using KolevDiamond.Core.Contracts;
using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Services.Admin;
using KolevDiamond.Core.Services.InvestmentCoin;
using KolevDiamond.Core.Services.InvestmentDiamond;
using KolevDiamond.Core.Services.MetalBar;
using KolevDiamond.Core.Services.Necklace;
using KolevDiamond.Core.Services.Ring;
using KolevDiamond.Infrastructure.Data;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KolevDiamond.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(
            this IServiceCollection services)
        {
            services
                .AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddApplicationJwt(
            this IServiceCollection services,
            IConfiguration config)
        {
            var jwtKey = config["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key not configured.");
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRingService, RingService>();
            services.AddScoped<INecklaceService, NecklaceService>();
            services.AddScoped<IMetalBarService, MetalBarService>();
            services.AddScoped<IInvestmentCoinService, InvestmentCoinService>();
            services.AddScoped<IInvestmentDiamondService, InvestmentDiamondService>();
            services.AddScoped<IAdminJewelryServiceContract, AdminJewelryService>();

            return services;
        }
    }
}
