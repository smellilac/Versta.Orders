using AutoMapper;
using Order.Application;
using Order.Application.CommonBehavior.Mapping;
using Order.WebApi.Persistance;

namespace Order.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public OrderDbContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = OrderContextFactory.Create();
        var configurationProvider = new MapperConfiguration(config =>
        {
            config.AddProfile(new AssemblyMappingProfile
                (typeof(IOrderDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        OrderContextFactory.Destroy(Context);
    }
}