using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Refugio.Seguranca;
using System;
using System.Text;

namespace Refugio.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegistrarRegrasSeguranca(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionStringSeg = configuration.GetConnectionString("LocalSeg");

            if (string.IsNullOrEmpty(connectionStringSeg))
                throw new Exception("Connection string não foi configurada");

            services.AddDbContext<UsersContexto>(options => options.UseSqlServer(connectionStringSeg));           

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<UsersContexto>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero
                });
        }
    }
}
