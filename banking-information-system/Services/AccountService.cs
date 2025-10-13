using banking_information_system.Data;
using banking_information_system.Models;
using Microsoft.EntityFrameworkCore;

namespace banking_information_system.Services
{
    public class AccountService: IAccountService
    {
        private readonly DevelopmentContext _dbContext;
        public AccountService(DevelopmentContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Account GetAccountById(string id)
        {
            var account = _dbContext.Accounts.FromSql($"SELECT [Account_ID] ,[Account_Number] ,[Account_Type] ,[Balance] ,[Opening_Date] ,[Active] ,[Branch_ID] FROM [development].[dbo].[Account] WHERE [Account_ID] = {id}");
            Account accountobj = account.FirstOrDefault();
            return accountobj;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            var accounts = _dbContext.Accounts.FromSql($"SELECT * FROM [development].[dbo].[Account]").ToList();
            
            foreach (var acc in accounts)
            {
                Console.WriteLine($"AccountId: {acc.Account_Id}, AccountNumber: {acc.Account_Number}, AccountType: {acc.Account_Type}, Balance: {acc.Balance}, OpeningDate: {acc.Opening_Date}, Active: {acc.Active}, BranchId: {acc.Branch_Id}");
            }

            IEnumerable<Account> accountsList = accounts;
            return accountsList;
        }


    }
}
