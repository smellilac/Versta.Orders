using MediatR;

namespace Order.Application.CQRS.Queries.GetOrderList;

public class GetOrdersQuery : IRequest<OrderListViewModel> {}
