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
        [Route("GetAllAccounts")]
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

        // Create an Account
        [HttpPost]
        [Route("CreateAccount")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            // Implementation for creating an account goes here
            if (account == null) { }

           var result =  _accountService.CreateAccount(account);

            return result;
        }

        // Update an Existing Account
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(string id, [FromBody] Account account)
        {
            if (account == null || string.IsNullOrEmpty(account.Account_Id))
            {
                return new BadRequestResult();
            }
            _accountService.UpdateAccount(account);
            // Implementation for updating an account goes here

            return Ok();
        }


    }
}
