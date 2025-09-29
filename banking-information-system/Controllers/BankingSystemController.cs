using banking_information_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace banking_information_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingSystemController : ControllerBase
    {
        private readonly ILogger<BankingSystemController> _logger;

        public BankingSystemController(ILogger<BankingSystemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccounts")]
        public IEnumerable<Account> Get()
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
