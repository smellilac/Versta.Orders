using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Application.CommonBehavior.CustomExceptions;

namespace Order.Application.CQRS.Queries.GetOrderList;

public class GetOrdersQueryHandler(IOrderDbContext context, IMapper mapper)
    : IRequestHandler<GetOrdersQuery, OrderListViewModel>
{
    private readonly IOrderDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderListViewModel> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var ordersQuery = await _context.Orders
            .ProjectTo<OrderDtoMappingForList>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (ordersQuery == null)
            throw new NotFoundException(nameof(Order));   
        else
            return new OrderListViewModel { OrdersList = ordersQuery };
        
    }
}
