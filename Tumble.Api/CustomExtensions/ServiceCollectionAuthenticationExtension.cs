using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Tumble.Api.Extensions
{
    public static class ServiceCollectionAuthenticationExtension
    {
        public static void AddTumbleAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var TokenEncryptionkey = configuration["TokenEncryptionkey"];
      
            var key = Encoding.ASCII.GetBytes(TokenEncryptionkey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(cfg =>
           {
              //cfg.Events = new JwtBearerEvents
              //{
              //    OnTokenValidated = context =>
              //    {
              //        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
              //        var userId = int.Parse(context.Principal.Identity.Name);
              //        var user = userService.GetById(userId);
              //        if (user == null)
              //        {
              //            // return unauthorized if user no longer exists
              //            context.Fail("Unauthorized");
              //        }
              //        return Task.CompletedTask;
              //    }
              //};
              cfg.RequireHttpsMetadata = false;
              cfg.SaveToken = true;
              cfg.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(key),
                  ValidateIssuer = false,
                  ValidateAudience = false,
              };
           });
        }
    }
}
