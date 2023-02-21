using Identity.API.Entity;
using Identity.API.Entity.DeliveryManEntity;

namespace Qaysar.Shared.Entity.DeliveryManEntity
{
    public class DeliveryMan
    {
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public string IdentityType { get; set; }
        public string IdentityImage { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthToken { get; set; }
        public string FcmToken { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public List<Review> Reviews { get; set; }
        public List<Delivery> Deliveries { get; set; }
        public List<DriverAddress> DriverAddresses { get; set; }

        public DeliveryMan()
        {
            //Reviews = new List<Review>();
            Deliveries = new List<Delivery>();
            DriverAddresses = new List<DriverAddress>();
        }
    }
}
