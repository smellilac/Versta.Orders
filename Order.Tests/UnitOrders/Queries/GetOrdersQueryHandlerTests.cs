using Order.Application.CQRS.Queries.GetOrderList;
using Order.Tests.Common;

namespace Order.Tests.UnitOrders.Queries;

public class GetOrdersQueryHandlerTests : TestBase
{
    public GetOrdersQueryHandlerTests(QueryTestFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetOrdersQueryHandler_Success()
    {
        // Arrange
        var handler = new GetOrdersQueryHandler(Context, Mapper);

        // Act: 
        var result = await handler.Handle(new GetOrdersQuery(), CancellationToken.None);

        // Assert: 
        Assert.NotNull(result);
        Assert.NotEmpty(result.OrdersList);
        Assert.Equal(7, result.OrdersList.Count());
    }
}