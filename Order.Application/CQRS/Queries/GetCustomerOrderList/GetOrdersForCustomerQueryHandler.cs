using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Application.CommonBehavior.CustomExceptions;
using System.Linq;

namespace Order.Application.CQRS.Queries.GetCustomerOrderList;

public class GetOrdersForCustomerQueryHandler(IOrderDbContext context, IMapper mapper)
    : IRequestHandler<GetOrdersForCustomerQuery, OrderListForCustomerVW>
{
    private readonly IOrderDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderListForCustomerVW> Handle(GetOrdersForCustomerQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Order> ordersQuery = _context.Orders.Where
            (o => o.ReceiverAddress == request.ReceiverAddress
            && o.ReceiverCity == request.ReceiverCity);
        // в будущем можно будет добавить например сортировку

        if (!await ordersQuery.AnyAsync(cancellationToken))
            throw new NotFoundException(nameof(Domain.Order));

        var filteredOrders =
            await ordersQuery.ProjectTo<OrderDtoForCustomerMapping>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (!filteredOrders.Any())
            throw new NotFoundException(nameof(Domain.Order));

        return new OrderListForCustomerVW { OrderListForCustomer = filteredOrders };
    }
}
