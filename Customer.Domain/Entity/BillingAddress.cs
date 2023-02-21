namespace Customer.Domain.Entity
{
    public class BillingAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ContactPersonName { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string BillingAddressData { get; set; }
    }
}
