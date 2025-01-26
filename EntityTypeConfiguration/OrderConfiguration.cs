using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order.Domain.Order>
{
    public void Configure(EntityTypeBuilder<Order.Domain.Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.SenderCity)
               .HasMaxLength(100) 
               .IsRequired();     

        builder.Property(order => order.SenderAddress)
               .HasMaxLength(250)
               .IsRequired();

        builder.Property(order => order.ReceiverCity)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(order => order.ReceiverAddress)
               .HasMaxLength(250)
               .IsRequired();

        builder.Property(order => order.Weight)
               .IsRequired();

        builder.Property(order => order.PickupDate)
               .IsRequired();

        builder.Property(order => order.OrderNumber)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
    }
}
