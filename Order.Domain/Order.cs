using System.Numerics;

namespace Order.Domain;

public class Order
{
    public Guid Id { get; set; }
    public string SenderCity { get; set; } 
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; } 
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; } 
    public DateTime PickupDate { get; set; }
    public long OrderNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.NotPlaced;
}