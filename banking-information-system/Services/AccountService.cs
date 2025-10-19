using banking_information_system.Data;
using banking_information_system.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CreateAccount(Account account)
        {
            /*_dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();*/

            _dbContext.Database.ExecuteSqlRaw(
                "INSERT INTO [development].[dbo].[Account] ([Account_ID], [Account_Number], [Account_Type], [Balance], [Opening_Date], [Active], [Branch_ID]) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                account.Account_Id,
                account.Account_Number,
                account.Account_Type,
                account.Balance,
                account.Opening_Date,
                account.Active,
                account.Branch_Id
            );

            return new OkResult();


        }

        public IActionResult UpdateAccount(Account account) 
        {
            if(account == null || string.IsNullOrEmpty(account.Account_Id))
            {
                return new BadRequestResult();
            }

            var existingAccount = _dbContext.Accounts.FromSql($"SELECT * FROM [development].[dbo].[Account] WHERE [Account_ID] = {account.Account_Id}").FirstOrDefault();
            if(existingAccount == null )
            {
                return new NotFoundResult();
            }
            _dbContext.Database.ExecuteSqlRaw(
                "UPDATE [development].[dbo].[Account] SET [Account_Number] = {1}, [Account_Type] = {2}, [Balance] = {3}, [Opening_Date] = {4}, [Active] = {5}, [Branch_ID] = {6} WHERE [Account_ID] = {0}",
                account.Account_Id,
                account.Account_Number,
                account.Account_Type,
                account.Balance,
                account.Opening_Date,
                account.Active,
                account.Branch_Id
            );

            return new OkResult();
        }


    }
}
