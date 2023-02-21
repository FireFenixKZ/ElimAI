namespace Qaysar.Shared.Entity.Customer
{
    public class CustomerWallet
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Identity.API.Entity.Customer.Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal LoyalityPoints { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
