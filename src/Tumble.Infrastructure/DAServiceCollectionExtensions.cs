using Microsoft.Extensions.DependencyInjection;
using Tumble.User.Domain.DataAccess.Interface.Account;
using Tumble.User.Infrastructure.Account;

namespace Tumble.User.Infrastructure
{
    public static class DAServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IDARegistrartion, DARegistrartion>();
            services.AddScoped<IDAUser, DAUser>();
        }
    }
}
