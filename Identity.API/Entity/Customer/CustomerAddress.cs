namespace Qaysar.Shared.Entity.Customer
{
    public class CustomerAddress : Address
    {
        public int CustomerId { get; set; }
        public Identity.API.Entity.Customer.Customer Customer { get; set; }
    }

    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
