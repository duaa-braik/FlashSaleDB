namespace FlashSaleDB.Entities;

public class Order
{
    public Guid Id { get; set; }

    public Guid CartId { get; set; }

    public Cart Cart { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; }

    public decimal Total { get; set; }

    public string OrderStatus { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}