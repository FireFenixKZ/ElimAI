namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryManTransaction
    {
        public int Id { get; set; }
        public int DeliveryManId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string TransactionId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
