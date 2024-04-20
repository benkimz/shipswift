using Microsoft.Extensions.DependencyInjection;
using ShipSwift.CoreBusiness;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.Infrastructure;

public static class ServiceRegistrar
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Shipper>, ShippersRepository>();
    }
}
