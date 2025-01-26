using AutoMapper;

namespace Order.Application.CommonBehavior.Mapping;

public interface IMapWith<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}