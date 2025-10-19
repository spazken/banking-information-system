using banking_information_system.Models;
using Microsoft.EntityFrameworkCore;

namespace banking_information_system.Data
{
    public class DevelopmentContext : DbContext
    {
        public DevelopmentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
