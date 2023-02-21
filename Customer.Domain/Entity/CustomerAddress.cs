namespace Customer.Domain.Entity
{
    public class CustomerAddress : Address
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
