namespace Customer.Domain.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime EmailVerifiedTime { get; set; }
        public string Password { get; set; } = string.Empty;
        public string RememberToken { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string CmFirebaseToken { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsPhoneVerified { get; set; }
        public string TemporaryToken { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public int UserId { get; set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }
        public List<CustomerWallet> CustomerWallets { get; set; }
        //public List<CartItem> CartItems { get; set; }
    }
}
