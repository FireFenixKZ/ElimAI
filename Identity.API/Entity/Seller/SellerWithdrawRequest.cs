namespace Identity.API.Entity.Seller
{
    public class SellerWithdrawRequest
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public bool OwnerApproval { get; set; }
        public int AdminId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionNote { get; set; }
        public bool AdminApproval { get; set; }
        public int StatusId { get; set; }
        public WithdrawRequestStatus RequestStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class WithdrawRequestStatus
    {
    }
}
