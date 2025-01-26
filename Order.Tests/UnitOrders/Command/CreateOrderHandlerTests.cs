using Order.Application.CQRS.Commands;
using Order.Tests.Common;
using System.ComponentModel.DataAnnotations;

namespace Order.Tests.UnitOrders.Command;

[Collection("QueryTests")]
public class CreateOrderHandlerTests : TestBase
{
    public CreateOrderHandlerTests(QueryTestFixture fixture) : base(fixture) { }

    [Fact]
    public async Task CreateNoteCommandHandler_Succes()
    {
        // Arrange
        var handler = new CreateOrderCommandHandler(Context);
        var orderId = Guid.NewGuid();
        var senderCity = "CityA";
        var senderAddress = "AddressA";
        var receiverCity = "CityB";
        var receiverAddress = "AddressB";
        var weight = 10.5;
        var pickupDate = new DateTime(2025, 1, 25, 10, 16, 19, DateTimeKind.Utc);

        // Act
        var resultId = await handler.Handle(
            new CreateOrderCommand
            {
                Id = orderId,
                SenderAddress = senderAddress,
                SenderCity = senderCity,
                ReceiverAddress = receiverAddress,
                ReceiverCity = receiverCity,
                Weight = weight,
                PickupDate = pickupDate,
            }, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, resultId);

        var createdOrder = await Context.Orders.FindAsync(resultId);
        Assert.NotNull(createdOrder);
        Assert.Equal(senderAddress, createdOrder.SenderAddress);
        Assert.Equal(senderCity, createdOrder.SenderCity);
        Assert.Equal(receiverAddress, createdOrder.ReceiverAddress);
        Assert.Equal(receiverCity, createdOrder.ReceiverCity);
        Assert.Equal(weight, createdOrder.Weight);
        Assert.Equal(pickupDate, createdOrder.PickupDate);
        Assert.Equal(Domain.OrderStatus.InProgress, createdOrder.Status);
    }

    [Fact]
    public async Task CreateOrderCommandHandler_InvalidData_ReturnsValidationErrors()
    {
        // Arrange
        var handler = new CreateOrderCommandHandler(Context);

        var invalidOrder = new CreateOrderCommand
        {
            Id = Guid.Empty, // !
            SenderCity = "", // !
            SenderAddress = "AddressA", 
            ReceiverCity = "ReceiverCity", 
            ReceiverAddress = "ReceiverAddress", 
            Weight = -10, // !
            PickupDate = DateTime.UtcNow.AddDays(-1), // !
        };

        // Act
        var validationResult = await ValidateCommand(invalidOrder);

        // Assert
        Assert.False(validationResult.IsValid);
        Assert.Contains(validationResult.Errors, error => error.ErrorMessage == "Id cant be empty Guid.");
        Assert.Contains(validationResult.Errors, error => error.ErrorMessage == "Sender city is required.");
        Assert.Contains(validationResult.Errors, error => error.ErrorMessage == "Weight must be greater than 0.");
        Assert.Contains(validationResult.Errors, error => error.ErrorMessage == "The date of cargo collection cannot be in the past.");

        var createdOrder = await Context.Orders.FindAsync(invalidOrder.Id);
        Assert.Null(createdOrder); 
    }

    private async Task<FluentValidation.Results.ValidationResult> ValidateCommand(CreateOrderCommand command)
    {
        var validator = new CreateOrderCommandValidator();
        var result = await validator.ValidateAsync(command);
        return result;
    }

}
