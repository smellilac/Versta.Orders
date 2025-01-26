using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Order.Application.CQRS.Commands;
using Order.Application.CQRS.Queries.GetCustomerOrderList;
using Order.Application.CQRS.Queries.GetOrderList;
using Order.WebApi.Models;

namespace Order.WebApi.Controllers;


public class OrderController(IMapper mapper) : BaseController
{
    private readonly IMapper _mapper = mapper;

    [HttpGet("GetAll")]
    public async Task<ActionResult<OrderListViewModel>> GetAll()
    {
        var query = new GetOrdersQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }


    [Route("create"), HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
    {
        var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
        command.Id = Guid.NewGuid();
        var Id = await Mediator.Send(command);

        return Ok(Id);
    }


    [HttpPost("GetOrdersForCustomers")]
    public async Task<ActionResult<OrderListForCustomerVW>> GetOrdersForCustomers([FromBody] OrdersForCustomersDto forCustomersDto)
    {
        var query = _mapper.Map<GetOrdersForCustomerQuery>(forCustomersDto);
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
}
