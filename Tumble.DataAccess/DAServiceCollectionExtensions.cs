using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.DataAccess.Account;

namespace Tumble.DataAccess
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
