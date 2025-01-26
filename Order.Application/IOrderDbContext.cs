using Microsoft.EntityFrameworkCore;


namespace Order.Application;

public interface IOrderDbContext
{
    DbSet<Domain.Order> Orders { get; set; } // !!!!!!!!!!!
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
