namespace FlashSaleDB.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        // how much we actually charged
        public decimal Amount { get; set; }

        // "Card", "Wallet", "COD" ...
        public string PaymentMethod { get; set; } = "Card";

        // FK -> Order
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        // NEW: who paid
        public Guid? UserId { get; set; }

        // NEW: to correlate with OrderService
        public Guid? CorrelationId { get; set; }

        // NEW: lifecycle
        // Pending | Succeeded | Failed
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
