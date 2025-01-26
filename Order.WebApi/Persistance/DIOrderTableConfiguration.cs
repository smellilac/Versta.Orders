using Microsoft.EntityFrameworkCore;
using Order.Application;

namespace Order.WebApi.Persistance;

public static class DIOrderTableConfiguration
{
    public static IServiceCollection AddPersistance(this IServiceCollection services,
       IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OrderDatabase");
        services.AddDbContext<OrderDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IOrderDbContext>(provider =>
            provider.GetRequiredService<OrderDbContext>()); 

        return services;
    }
}
