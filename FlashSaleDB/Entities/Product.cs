namespace FlashSaleDB.Entities;

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Category { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public string? ImageUrl { get; set; }

    public DateOnly ExpirationDate { get; set; }
    
    public int? SaleId { get; set; }
    
    public Sale? Sale { get; set; }

    public Inventory Inventory { get; set; }

    public ICollection<Cart> Carts { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}