using AutoMapper;
using Order.WebApi.Persistance;

namespace Order.Tests.Common;

public abstract class TestBase : IClassFixture<QueryTestFixture>
{
    protected readonly OrderDbContext Context;
    protected readonly IMapper Mapper;

    protected TestBase(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }
}