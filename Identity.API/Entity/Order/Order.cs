using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.API.Entity.Customer;
using Identity.API.Entity.DeliveryManEntity;
using Qaysar.Shared.Entity;
using Qaysar.Shared.Entity.Customer;
using Qaysar.Shared.Entity.DeliveryManEntity;
using Qaysar.Shared.Entity.Order;
using CustomerAddress = Qaysar.Shared.Entity.Customer.CustomerAddress;

namespace Qaysar.Shared.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderPlacedDateTime { get; set; }
        public DateTime OrderApprovedDateTime { get; set; }
        public DateTime OrderPreparedDateTime { get; set; }
        public DateTime OrderDeliveredDateTime { get; set; }
        public DateTime OrderCanceledDateTime { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string VerificationCode { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; } = decimal.Zero;
        public decimal DeliveryPrice { get; set; } = decimal.Zero;
        public string IsPause { get; set; } = string.Empty;
        public string? Cause { get; set; }

        public int ShippingMethodId { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal DiscountAmount { get; set; } = decimal.Zero;
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionRef { get; set; } = string.Empty;
        public List<OrderItem> OrderItems { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }
}
