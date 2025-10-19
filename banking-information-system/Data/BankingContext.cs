using banking_information_system.Models;
using Microsoft.EntityFrameworkCore;

namespace banking_information_system.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
