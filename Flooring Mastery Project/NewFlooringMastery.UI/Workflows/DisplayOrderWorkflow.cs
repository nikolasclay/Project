using NewFlooringMastery.BLL;
using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows
{
    class DisplayOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();

            Console.WriteLine("Lookup an order");
            Console.WriteLine("--------------------");

            DateTime orderDate = ConsoleIO.GetDate();
            LookupOrderResponse response = manager.LookupOrder(orderDate);


            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Orders);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
                
            }
            Console.ReadKey();
        }
    }
}
