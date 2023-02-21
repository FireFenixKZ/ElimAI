namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryManNotification
    {
        public int Id { get; set; }
        public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int? OrderId { get; set; }
        public Shared.Order.Order Order { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
