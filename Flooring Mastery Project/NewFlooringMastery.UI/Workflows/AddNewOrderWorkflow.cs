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
    class AddNewOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            SaveNewOrderRequest saveRequest = new SaveNewOrderRequest();
            saveRequest.Order = new Order();

            Console.Clear();
            Console.WriteLine("ADD A NEW ORDER");
            Console.WriteLine("****************************");

            DateTime orderDate = ConsoleIO.GetDate();
            saveRequest.Order.OrderDate = orderDate.Date;

            //Cannot be blank. Allowed to contain [a-z][0-9]
            string userInput = ConsoleIO.GetUserName();
            saveRequest.Order.CustomerName = userInput;

            //State must be checked against the tax file.

            string stateInput = ConsoleIO.GetStateName();
            GetStateResponse stateResponse = manager.GetStateTaxData(stateInput);
            saveRequest.Order.State = stateInput;

            //verify that is the correct product type
            string productInput = ConsoleIO.GetProduct();
            ProductTypeResponse productResponse = manager.FindProductByType(productInput);
            if (productResponse.Success)
            {
                saveRequest.Order.ProductInfo = productResponse.ProductTypeInfo;
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(productResponse.Message);
            }
            


            string areaInput = ConsoleIO.GetArea();
            saveRequest.Order.Area = decimal.Parse(areaInput);

            //DisplayOrderResponse displayOrderresponse = manager.DisplayOrders(orderDate);

            //if (displayOrderresponse.Success)
            //{
            //    ConsoleIO.DisplaySingleAddOrderDetail(displayOrderresponse.Orders);
            //}
            //else
            //{
            //    Console.WriteLine("An error occurred: ");
            //    Console.WriteLine(response.Message);
            //    Console.WriteLine("Press any key to continue...");
            //    Console.ReadKey();
            //}

            Console.WriteLine("Would you like to save this order?: Y/N");
            string saveResponse = Console.ReadLine().ToUpper();
            if(saveResponse == "Y")
            {
                manager.SaveNewOrder(saveRequest.Order);
            }
            else
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
