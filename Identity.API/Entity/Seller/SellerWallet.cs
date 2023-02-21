namespace Identity.API.Entity.Seller
{
    public class SellerWallet
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public decimal TotalEarning { get; set; }
        public decimal Withdrawn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal CommissionGiven { get; set; }
        public decimal PendingWithdraw { get; set; }
        public decimal DeliveryChargeEarned { get; set; }
        public decimal CollectedCash { get; set; }
        public decimal TotalTaxCollected { get; set; }
    }
}
