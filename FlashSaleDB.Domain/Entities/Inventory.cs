namespace FlashSaleDB.Domain.Entities;

public class Inventory
{
    public int Id { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public int AvailableQuantity { get; set; }
    
    public int ReservedQuantity { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}