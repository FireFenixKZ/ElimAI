namespace Customer.Application.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string CmFireBaseToken { get; set; }
        public bool IsActive { get; set; }
        public string TemporaryToken { get; set; }
        public string PaymentCardLastFour { get; set; }
        public string PaymentCardBrand { get; set; }
        public string PaymentCardFawryToken { get; set; }
        public DateTime EmailVerifiedDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public CustomerAddressDTO CustomerAddressDto { get; set; }
    }
}
