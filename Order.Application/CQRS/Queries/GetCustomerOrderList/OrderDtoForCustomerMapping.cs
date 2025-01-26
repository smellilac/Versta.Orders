using AutoMapper;
using Order.Application.CommonBehavior.Mapping;
using System.Numerics;

namespace Order.Application.CQRS.Queries.GetCustomerOrderList;

public class OrderDtoForCustomerMapping : IMapWith<Domain.Order>
{
    public Guid Id { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; }
    public DateTime PickupDate { get; set; }
    public long OrderNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Order, OrderDtoForCustomerMapping>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(order => order.Id))
            .ForMember(dto => dto.ReceiverCity, opt => opt.MapFrom(order => order.ReceiverCity))
            .ForMember(dto => dto.ReceiverAddress, opt => opt.MapFrom(order => order.ReceiverAddress))
            .ForMember(dto => dto.Weight, opt => opt.MapFrom(order => order.Weight))
            .ForMember(dto => dto.PickupDate, opt => opt.MapFrom(order => order.PickupDate))
            .ForMember(dto => dto.OrderNumber, opt => opt.MapFrom(order => order.OrderNumber));
    }
}
