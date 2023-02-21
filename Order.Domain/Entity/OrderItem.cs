using Qaysar.Shared.Entity.DeliveryManEntity;

namespace Qaysar.Shared.Entity.Order
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Shared.Order.Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ProductDetails { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public List<ProductVariant> ProductVariants { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DiscountType { get; set; } = string.Empty;
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
