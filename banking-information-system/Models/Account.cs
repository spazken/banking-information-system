namespace banking_information_system.Models
{
    public class Account
    {
        public string Id {get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string OpeningDate { get; set; }
        public string Active { get; set; }
        public string BranchId { get; set; }
    }
}
