using AutoMapper;
using Order.Application.CommonBehavior.Mapping;
using Order.Application.CQRS.Queries.GetCustomerOrderList;

namespace Order.Application.CQRS.Queries.GetOrderList;

public class OrderDtoMappingForList : IMapWith<Domain.Order>
{
    public Guid Id { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public string? ReceiverPhone { get; set; }
    public double Weight { get; set; }
    public DateTime PickupDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Order, OrderDtoMappingForList>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(order => order.Id))
            .ForMember(dto => dto.ReceiverCity, opt => opt.MapFrom(order => order.ReceiverCity))
            .ForMember(dto => dto.ReceiverAddress, opt => opt.MapFrom(order => order.ReceiverAddress))
            .ForMember(dto => dto.Weight, opt => opt.MapFrom(order => order.Weight))
            .ForMember(dto => dto.PickupDate, opt => opt.MapFrom(order => order.PickupDate));
    }
}
