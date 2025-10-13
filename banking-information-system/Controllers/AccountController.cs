using Microsoft.AspNetCore.Mvc;
using banking_information_system.Models;
using banking_information_system.Services;

namespace banking_information_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Get all accounts
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> GetAllAccount()
        {
          

            var accounts = _accountService.GetAllAccounts();

            return accounts;
        }

        // Get account by ID
        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(string id) 
        {
            if (id == null)
            {
                return BadRequest("Account ID is required.");
            }

            var result =  _accountService.GetAccountById(id);

            return result;
            
        }

    }
}
