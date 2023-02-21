using Qaysar.Shared.Entity;
using Qaysar.Shared.Entity.Customer;
using Qaysar.Shared.Entity.DeliveryManEntity;
using Qaysar.Shared.Entity.Order;
using DeliveryStatus = Qaysar.Shared.Entity.DeliveryManEntity.DeliveryStatus;

namespace Identity.API.Entity.DeliveryManEntity
{
    public class Delivery
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Qaysar.Shared.Order.Order Order { get; set; }
        public int ShopAddressId { get; set; }
        public ShopAddress ShopAddress { get; set; }
        public int CustomerAddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public decimal DeliveryPrice { get; set; }
        public int DeliveryTypeId { get; set; }
        public int DeliveryStatusId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string DeliveryServiceName { get; set; }
        public string ThirdPartyDeliveryTrackingId { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime ExpectedDeliveryDateTime { get; set; }
        public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool IsLocalOrder { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
