namespace FlashSaleDB.Entities;

public class Cart
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public ICollection<Product> Products { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}