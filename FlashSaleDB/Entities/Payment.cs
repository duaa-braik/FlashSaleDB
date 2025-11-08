namespace FlashSaleDB.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "Card";

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid? UserId { get; set; }

        public string? CorrelationId { get; set; }

        // Pending | Succeeded | Failed
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
