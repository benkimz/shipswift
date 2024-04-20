using Microsoft.Extensions.DependencyInjection;
using ShipSwift.CoreBusiness;

namespace ShipSwift.Infrastructure;

public static class ServiceRegistrar
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IShippersRepository, ShippersRepository>();
    }
}
