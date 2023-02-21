namespace Identity.API.Entity.Seller
{
    public class SellerWalletHistory
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Payment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
