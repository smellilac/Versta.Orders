using MediatR;

namespace Order.Application.CQRS.Queries.GetCustomerOrderList;

public class GetOrdersForCustomerQuery : IRequest<OrderListForCustomerVW>
{
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
}
