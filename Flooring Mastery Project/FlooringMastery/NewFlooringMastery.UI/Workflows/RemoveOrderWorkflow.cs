using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Requests;
using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows
{
    class RemoveOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("REMOVE AN ORDER");
            Console.WriteLine("*****************");
            Console.WriteLine();

            DateTime orderDate = ConsoleIO.GetDate();
            string orderNumber = ConsoleIO.GetOrderNumber();

            LoadOrderResponse response = manager.LoadRequestedOrder(orderDate, orderNumber);

            if (response.Success)
            {
                ConsoleIO.DisplaySingleOrderDetail(response.Order);
                Console.WriteLine();
                Console.WriteLine("Are you sure you want to delete the order above? Y/N");
                string userInput = Console.ReadLine().ToUpper();
                if(userInput == "Y")
                {
                    manager.RemoveOrder(response.Order);
                    Console.WriteLine("This order has been removed.");

                }

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
    }
}

