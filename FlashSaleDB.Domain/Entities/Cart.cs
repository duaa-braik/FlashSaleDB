namespace FlashSaleDB.Domain.Entities;

public class Cart
{
    public string Id { get; set; }

    public string UserId { get; set; }
    
    public ICollection<Product> Products { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}