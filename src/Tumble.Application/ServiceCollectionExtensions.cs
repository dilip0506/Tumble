using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tumble.Application.Account;
using Tumble.Application.Email;
using Tumble.Domain.Services.Interface.Account;
using Tumble.Domain.Services.Interface.Email;

namespace Tumble.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISendEmail, SendEmail>();
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
