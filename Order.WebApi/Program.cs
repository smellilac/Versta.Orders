using Microsoft.EntityFrameworkCore;
using Order.Application.CommonBehavior;
using Order.Application.CommonBehavior.Mapping;
using Order.WebApi.Middleware;
using Order.WebApi.Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddPersistance(configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var dbContext = serviceProvider.GetRequiredService<OrderDbContext>();
        dbContext.Database.Migrate();  
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating the database: {ex.Message}");
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

app.Run();
