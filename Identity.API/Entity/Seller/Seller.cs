using Qaysar.Shared.Entity;

namespace Identity.API.Entity.Seller
{
    public class Seller
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public string HolderName { get; set; }
        public string AuthToken { get; set; }
        public decimal SalesCommissionPercentage { get; set; }
        public string Gst { get; set; }
        public List<SellerShop> SellerShop { get; set; }
        public string CmFirebaseToken { get; set; }
        public bool PosStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
