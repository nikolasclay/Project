using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            //ask the user to give us an account number
            Console.WriteLine("Please enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Please enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Your deposit was completed!");
                Console.WriteLine($"Account number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance}");
                Console.WriteLine($"Amount deposited: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");

            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...:");
            Console.ReadKey();
        }
        
    }
}
