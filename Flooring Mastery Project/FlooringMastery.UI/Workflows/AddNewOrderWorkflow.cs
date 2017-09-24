using FlooringMastery.BLL;
using FlooringMastery.Models.Requests;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    class AddNewOrderWorkflow
    {

        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Add a new order");
            Console.WriteLine("--------------------------");
            
            AddEditOrderRequest request = new AddEditOrderRequest();
            request.Order = new Models.Order();

            //Cannot be blank. Allowed to contain [a-z][0-9]
            string userInput = ConsoleIO.GetUserName();
            request.Order.CustomerName = userInput;

            DateTime orderDate = ConsoleIO.ValidateDate();
            request.Order.OrderDate = orderDate;

            //State must be checked against the tax file.
            Console.WriteLine("Please enter a state: ");
            string stateInput = Console.ReadLine();
            request.Order.State = stateInput;

            //verify that is the correct product type
            Console.WriteLine("Please enter the Product Type: ");
            string productInput = Console.ReadLine();
            request.Order.ProductType = productInput;

            Console.WriteLine("Please enter the total area you want to floor in square feet. Minimum 100 sq ft.");
            string areaInput = Console.ReadLine();
            request.Order.Area = decimal.Parse(areaInput);

            AddEditOrderResponse response = manager.AddOrder(request);

            if (response.Success)
            {
                ConsoleIO.DisplayAddOrderDetails(response.Order);
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
