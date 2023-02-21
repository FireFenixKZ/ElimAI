namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
