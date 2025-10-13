using banking_information_system.Models;

namespace banking_information_system.Services
{
    public interface IAccountService
    {
        public IEnumerable<Account> GetAllAccounts();
        public Account GetAccountById(string id);
    }
}