namespace FlashSaleDB.Domain.Entities;

public class Order
{
    public string Id { get; set; }

    public string CartId { get; set; }

    public Cart Cart { get; set; }
    
    public string UserId { get; set; }

    public User User { get; set; }

    public decimal Total { get; set; }

    public string OrderStatus { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}