using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.WriteLine("Please enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Please enter the amount you'd like to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw completed!");
                Console.WriteLine($"Account Number : {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Withdraw amount: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
            }
            if (!response.Success)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}

