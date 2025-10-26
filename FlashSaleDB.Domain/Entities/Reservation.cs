namespace FlashSaleDB.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    
    public string OrderId { get; set; }

    public Order Order { get; set; }

    public string ProductId { get; set; }

    public Product Product { get; set; }

    public DateTime ExpiryTime { get; set; }
}