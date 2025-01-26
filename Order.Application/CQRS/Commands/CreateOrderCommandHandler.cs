using MediatR;

namespace Order.Application.CQRS.Commands;

public class CreateOrderCommandHandler(IOrderDbContext context) 
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderDbContext _context = context;

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Order()
        {
            Id = Guid.NewGuid(),
            SenderAddress = request.SenderAddress,
            SenderCity = request.SenderCity,     
            ReceiverAddress = request.ReceiverAddress,
            ReceiverCity = request.ReceiverCity,
            Weight = request.Weight,
            PickupDate = request.PickupDate,
            Status = Domain.OrderStatus.InProgress
        };

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
