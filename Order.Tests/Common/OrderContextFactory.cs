using Microsoft.EntityFrameworkCore;
using Order.WebApi.Persistance;

namespace Order.Tests.Common;

internal class OrderContextFactory
{
    public static OrderDbContext Create()
    {
        var contextOptions = new DbContextOptionsBuilder<OrderDbContext>()
            .UseInMemoryDatabase("InMemoryTestDatabase").Options;

        var context = new OrderDbContext(contextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.AddRange(
             new Domain.Order
             {
                 SenderCity = "CityA",
                 SenderAddress = "AddressA",
                 ReceiverCity = "CityX", // Один и тот же город
                 ReceiverAddress = "AddressX", // Один и тот же адрес
                 Weight = 5.5,
                 PickupDate = new DateTime(2025, 1, 25, 10, 16, 19, DateTimeKind.Utc)
             },
            new Domain.Order
            {
                SenderCity = "CityB",
                SenderAddress = "AddressB",
                ReceiverCity = "CityY",
                ReceiverAddress = "AddressY",
                Weight = 10.0,
                PickupDate = new DateTime(2025, 1, 26, 12, 30, 0, DateTimeKind.Utc)
            },
            new Domain.Order
            {
                SenderCity = "CityC",
                SenderAddress = "AddressC",
                ReceiverCity = "CityX", // Один и тот же город
                ReceiverAddress = "AddressX", // Один и тот же адрес
                Weight = 7.8,
                PickupDate = new DateTime(2025, 1, 27, 9, 0, 0, DateTimeKind.Utc)
            },
            new Domain.Order
            {
                SenderCity = "CityD",
                SenderAddress = "AddressD",
                ReceiverCity = "CityZ",
                ReceiverAddress = "AddressZ",
                Weight = 15.2,
                PickupDate = new DateTime(2025, 1, 28, 14, 45, 0, DateTimeKind.Utc)
            },
            new Domain.Order
            {
                SenderCity = "CityE",
                SenderAddress = "AddressE",
                ReceiverCity = "CityX", // Один и тот же город
                ReceiverAddress = "AddressX", // Один и тот же адрес
                Weight = 3.5,
                PickupDate = new DateTime(2025, 1, 29, 11, 15, 0, DateTimeKind.Utc)
            },
            new Domain.Order
            {
                SenderCity = "CityF",
                SenderAddress = "AddressF",
                ReceiverCity = "CityY", // Один и тот же город
                ReceiverAddress = "AddressY", // Один и тот же адрес
                Weight = 8.0,
                PickupDate = new DateTime(2025, 1, 30, 13, 0, 0, DateTimeKind.Utc)
            },
            new Domain.Order
            {
                SenderCity = "CityG",
                SenderAddress = "AddressG",
                ReceiverCity = "CityW",
                ReceiverAddress = "AddressW",
                Weight = 12.3,
                PickupDate = new DateTime(2025, 1, 31, 15, 30, 0, DateTimeKind.Utc)
            });

        context.SaveChanges();
        return context;
    }

    public static void Destroy(OrderDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
