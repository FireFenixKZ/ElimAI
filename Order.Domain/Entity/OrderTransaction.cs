using Qaysar.Shared.Entity;
using Qaysar.Shared.Entity.Seller;

namespace Qaysar.Shared.Order
{
    public class OrderTransaction
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal ShopAmount { get; set; }
        public decimal AdminCommission { get; set; }
        public string ReceivedBy { get; set; }
        public string Status { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal Tax { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        public string SellerIs { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public string DeliveredBy { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
    }
}
