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
    class EditOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            SaveCurrentOrderRequest request = new SaveCurrentOrderRequest();
            request.Order = new Order();


            Console.Clear();

            DateTime orderDate = ConsoleIO.GetDate();

            int orderNumber = ConsoleIO.GetOrderNumber();

            LoadOrderResponse response = manager.LoadRequestedOrder(orderDate, orderNumber);

            if (response.Success)
            {
                ConsoleIO.DisplaySingleOrderDetail(response.Order);
                Console.WriteLine("**************************************************");
                Console.WriteLine();
                Console.WriteLine();
                ConsoleIO.MenuForEditOrder(response.Order);
            }
            else
            {
                response.Success = false;
                response.Message = "An error occured: ";
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

