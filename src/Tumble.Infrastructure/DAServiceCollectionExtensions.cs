using Microsoft.Extensions.DependencyInjection;
using Tumble.Domain.DataAccess.Interface.Account;
using Tumble.Infrastructure.Account;

namespace Tumble.Infrastructure
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
