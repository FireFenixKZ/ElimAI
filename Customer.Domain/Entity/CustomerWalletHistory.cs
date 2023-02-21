namespace Customer.Domain.Entity
{
    public class CustomerWalletHistory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMethod { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
