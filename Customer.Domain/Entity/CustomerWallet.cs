namespace Customer.Domain.Entity
{
    public class CustomerWallet
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal LoyalityPoints { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
