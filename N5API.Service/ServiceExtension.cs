using Microsoft.Extensions.DependencyInjection;
using N5API.Domain.Abstractions.Repository;
using N5API.Infraestructure.Data.Repositories;

namespace N5API.Service
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
        }
    }
}
