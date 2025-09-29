using Microsoft.AspNetCore.Mvc;
using banking_information_system.Models;

namespace banking_information_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {




        // Get all accounts

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> GetAllAccount()
        {
            List<Account> accounts = new List<Account>
            {
                new Account { Id = "1", AccountNumber = "123456", AccountType = "Savings", Balance = 1000.00M, OpeningDate = "2022-01-01", Active = "Yes", BranchId = "B001" },
                new Account { Id = "2", AccountNumber = "654321", AccountType = "Checking", Balance = 500.00M, OpeningDate = "2022-02-01", Active = "Yes", BranchId = "B002" }
            };
            return accounts;
        }

    }
}
