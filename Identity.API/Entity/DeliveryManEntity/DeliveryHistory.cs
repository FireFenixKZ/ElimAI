namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DeliverymanId { get; set; }
        public DateTime Time { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
