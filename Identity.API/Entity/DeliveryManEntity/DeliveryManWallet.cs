namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryManWallet
    {
        public int Id { get; set; }
        public int DeliveryManId { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal CashInHand { get; set; }
        public decimal PendingWithdraw { get; set; }
        public decimal TotalWithdraw { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? DeliveredOrdersCount { get; set; }
        public int? TotalOrders { get; set; }
    }
}
