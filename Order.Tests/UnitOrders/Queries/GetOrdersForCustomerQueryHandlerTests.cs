using AutoMapper;
using Order.Application.CommonBehavior.CustomExceptions;
using Order.Application.CQRS.Queries.GetCustomerOrderList;
using Order.Tests.Common;

namespace Order.Tests.UnitOrders.Queries;

public class GetOrdersForCustomerQueryHandlerTests : TestBase
{
    public GetOrdersForCustomerQueryHandlerTests(QueryTestFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetOrdersForCustomerQueryHandler_Success()
    {
        // Arrange: 
        var handler = new GetOrdersForCustomerQueryHandler(Context, Mapper);
        var query = new GetOrdersForCustomerQuery
        {
            ReceiverCity = "CityX",
            ReceiverAddress = "AddressX"
        };

        // Act: 
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert:
        Assert.NotNull(result);
        Assert.NotEmpty(result.OrderListForCustomer);
        Assert.Equal(3, result.OrderListForCustomer.Count());  

        var firstOrder = result.OrderListForCustomer.First();
        Assert.Equal("CityX", firstOrder.ReceiverCity);
        Assert.Equal("AddressX", firstOrder.ReceiverAddress);

        var secondOrder = result.OrderListForCustomer.ElementAt(1); 
        Assert.NotNull(secondOrder);
        Assert.Equal("CityX", secondOrder.ReceiverCity);
        Assert.Equal("AddressX", secondOrder.ReceiverAddress);

        var thirdOrder = result.OrderListForCustomer.Last();
        Assert.Equal("CityX", thirdOrder.ReceiverCity);
        Assert.Equal("AddressX", thirdOrder.ReceiverAddress);
    }

    [Fact]
    public async Task GetOrdersForCustomerQueryHandler_NotFound()
    {
        // Arrange:
        var handler = new GetOrdersForCustomerQueryHandler(Context, Mapper);
        var query = new GetOrdersForCustomerQuery
        {
            ReceiverCity = "NonExistentCity",
            ReceiverAddress = "NonExistentAddress"
        };

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(query, CancellationToken.None));
    }
}
