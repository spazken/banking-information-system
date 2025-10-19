using banking_information_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace banking_information_system.Services
{
    public interface IAccountService
    {
        public IEnumerable<Account> GetAllAccounts();
        public Account GetAccountById(string id);

        public IActionResult CreateAccount(Account account);

        public IActionResult UpdateAccount(Account account);
    }
}