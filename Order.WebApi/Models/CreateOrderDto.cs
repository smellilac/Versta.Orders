using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Order.Application.CommonBehavior.Mapping;
using Order.Application.CQRS.Commands;
using System.ComponentModel.DataAnnotations;

namespace Order.WebApi.Models;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
    public string SenderCity { get; set; }

    public string SenderAddress { get; set; }

    public string ReceiverCity { get; set; }

    public string ReceiverAddress { get; set; }


    public decimal Weight { get; set; }

    public DateTime PickupDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
            .ForMember(dest => dest.SenderCity, opt => opt.MapFrom(src => src.SenderCity))
            .ForMember(dest => dest.SenderAddress, opt => opt.MapFrom(src => src.SenderAddress))
            .ForMember(dest => dest.ReceiverCity, opt => opt.MapFrom(src => src.ReceiverCity))
            .ForMember(dest => dest.ReceiverAddress, opt => opt.MapFrom(src => src.ReceiverAddress))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.PickupDate, opt => opt.MapFrom(src => src.PickupDate));
    }
}
