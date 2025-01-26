using AutoMapper;
using Order.Application.CommonBehavior.Mapping;
using Order.Application.CQRS.Queries.GetCustomerOrderList; 

namespace Order.WebApi.Models;

public class OrdersForCustomersDto : IMapWith<GetOrdersForCustomerQuery>
{
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrdersForCustomersDto, GetOrdersForCustomerQuery>()
            .ForMember(dest => dest.ReceiverCity, opt => opt.MapFrom(src => src.ReceiverCity))
            .ForMember(dest => dest.ReceiverAddress, opt => opt.MapFrom(src => src.ReceiverAddress));
    }
}
