using NewFlooringMastery.BLL;
using NewFlooringMastery.Data;
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
            bool isValid = false;
            OrderManager manager = OrderManagerFactory.Create();
            SaveNewOrderRequest saveRequest = new SaveNewOrderRequest();
            saveRequest.Order = new Order();

            Console.Clear();
            Console.WriteLine("ADD A NEW ORDER");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine("NEW ORDERS MUST BE FUTURE DATED!");
            while (!isValid)
            {    
                Console.WriteLine();
                DateTime orderDate = ConsoleIO.GetDate();
                Console.WriteLine();
                if (orderDate > DateTime.Today)
                {
                    saveRequest.Order.OrderDate = orderDate;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("The new order must be futured dated.");
                }
            }
            //Cannot be blank. Allowed to contain [a-z][0-9]

            string userInput = ConsoleIO.GetUserName();
            Console.WriteLine();
            saveRequest.Order.CustomerName = userInput;


            //State must be checked against the tax file.

            bool validState = false;
            while(!validState)
            {
                string stateInput = ConsoleIO.GetStateName();
                Console.WriteLine();
                GetStateResponse stateResponse = manager.GetStateTaxData(stateInput);
                if (stateResponse.Success)
                {
                    saveRequest.Order.StateTaxData = stateResponse.TaxData;
                    validState = true;
                }
                else
                {
                    stateResponse.Success = false;
                    Console.WriteLine("That state does not exist!");
                }

            }

            //verify that is the correct product type
            bool validProduct = false;
            while (!validProduct)
            {
                ProductRepo repo = new ProductRepo();
                string productType = ConsoleIO.GetProduct(repo.LoadProducts());
                Console.WriteLine();

                ProductTypeResponse productResponse = manager.FindProductByType(productType);
                if (productResponse.Success)
                {
                    saveRequest.Order.ProductDetail = productResponse.ProductType;
                    validProduct = true;
                }
                else
                {
                    productResponse.Success = false;
                    Console.WriteLine("That product does not exist!");
                    //Console.WriteLine(productResponse.Message);
                }

            }


            string areaInput = ConsoleIO.GetArea();
            saveRequest.Order.Area = decimal.Parse(areaInput);

            Console.WriteLine("Would you like to save this order?: Y/N");
            string saveResponse = Console.ReadLine().ToUpper();
            if(saveResponse == "Y")
            {
                manager.SaveNewOrder(saveRequest.Order);
            }
            else
            {
                Console.WriteLine("Press any key to return to Menu");
                Console.ReadKey();
                Menu.Start();
            }
        }
    }
}
