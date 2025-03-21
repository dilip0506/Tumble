using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tumble.Core.Services.Interface.Account;
using Tumble.Core.Services.Interface.Email;
using Tumble.DataAccess;
using Tumble.Services.Account;
using Tumble.Services.Email;

namespace Tumble.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISendEmail, SendEmail>();

            services.AddDataAccess();
        }

        public static void AddMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingAccount());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
