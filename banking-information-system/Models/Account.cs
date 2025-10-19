using System.ComponentModel.DataAnnotations;

namespace banking_information_system.Models
{
    public class Account
    {
        [Key]
        public string Account_Id {get; set; }
        public string Account_Number { get; set; }
        public string Account_Type { get; set; }
        public string Balance { get; set; }
        public string Opening_Date { get; set; }
        public string Active { get; set; }
        public string Branch_Id { get; set; }
    }
}
