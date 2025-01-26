using Microsoft.EntityFrameworkCore;
using Order.Application;
using EntityTypeConfiguration;

namespace Order.WebApi.Persistance;

public class OrderDbContext : DbContext, IOrderDbContext
{
    public DbSet<Domain.Order> Orders { get; set; } // !!!!!

    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}

