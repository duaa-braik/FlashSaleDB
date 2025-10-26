namespace FlashSaleDB.Domain.Entities;

public class Payment
{
    public string Id { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }
    
    public string OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}