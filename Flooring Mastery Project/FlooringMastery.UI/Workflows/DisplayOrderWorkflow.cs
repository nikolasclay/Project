using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    class DisplayOrderWorkflow
    {

        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();

            Console.WriteLine("Lookup an order");
            Console.WriteLine("--------------------");

            DateTime orderDate = ConsoleIO.ValidateDate();
            string userName = ConsoleIO.GetUserName();
            DisplayOrderResponse response = manager.DisplayOrders(orderDate, userName);

            
            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Orders);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
