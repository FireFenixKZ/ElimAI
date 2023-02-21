namespace Customer.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool IsActive { get; set; }
    }
}
