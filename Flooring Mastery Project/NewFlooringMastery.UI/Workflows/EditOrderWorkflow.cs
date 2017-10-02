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
            bool isValid = false;
            SaveCurrentOrderRequest request = new SaveCurrentOrderRequest();
            request.Order = new Order();


            Console.Clear();

            while (!isValid)
            {
                DateTime orderDate = ConsoleIO.GetDate();

                string orderNumber = ConsoleIO.GetOrderNumber();

                LoadOrderResponse response = manager.LoadRequestedOrder(orderDate, orderNumber);

                if (response.Success)
                {
                    ConsoleIO.DisplaySingleOrderDetail(response.Order);
                    Console.WriteLine("**************************************************");
                    Console.WriteLine();
                    Console.WriteLine();
                    ConsoleIO.MenuForEditOrder();
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
}




//                EditOrderResponse response = manager.SaveCurrentOrder(request);

//                if (response.Success)
//                {
//                    ConsoleIO.DisplayEditedOrderDetail(response.Order);
//                    ConsoleIO.SaveThisOrder();
//                }
//                else
//                {
//                    Console.WriteLine("An error occurred: ");
//                    Console.WriteLine(response.Message);
//                }
//                Console.WriteLine("Press any key to continue...");
//                Console.ReadKey();
//            }
//        }
//    }
//}
