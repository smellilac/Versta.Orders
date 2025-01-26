using MediatR;

namespace Order.Application.CQRS.Commands;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; }
    public DateTime PickupDate { get; set; }
}
