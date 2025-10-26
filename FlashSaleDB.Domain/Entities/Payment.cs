namespace FlashSaleDB.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }
    
    public Guid OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}