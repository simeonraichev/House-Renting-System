using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HouseRentingServiceExtensionCollection
    {
        public static IServiceCollection AddApplicationSevices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IHouseService, HouseService>();

            return services;
        }
    }
}
