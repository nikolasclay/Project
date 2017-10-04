using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using NewFlooringMastery.UI.Workflows.OrderEdits;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Order> orders)
        {
            Console.WriteLine("YOUR ORDER DETAILS ARE BELOW");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            foreach (Order order in orders)
            {

                Console.WriteLine($"Order Number: {order.OrderNumber}" + " | " + $"OrderDate: {order.OrderDate}");
                Console.WriteLine("*************************************");
                Console.WriteLine();
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"State: {order.StateTaxData.StateName}");
                Console.WriteLine($"Tax Rate: {order.StateTaxData.TaxRate}");
                Console.WriteLine($"Product Type: {order.ProductDetail.ProductType}");
                Console.WriteLine($"Area: {order.Area}");
                Console.WriteLine($"Cost Per Square Foot: ${order.ProductDetail.CostPerSquareFoot}");
                Console.WriteLine($"Labor Cost Per Square Foot: ${order.ProductDetail.LaborCostPerSquareFoot}");
                Console.WriteLine($"Material Cost: ${order.MaterialCost}");
                Console.WriteLine($"Labor Cost: ${order.LaborCost}");
                Console.WriteLine($"Tax: ${order.Tax}");
                Console.WriteLine($"Total: ${order.Total}");

            }
        }
        public static string GetOrderNumber()
        {
            Console.WriteLine("Please enter your order number: ");
            string userChoice = Console.ReadLine();
            return userChoice;
        }
        public static void MenuForEditOrder(Order order)
        {
            bool isValid = false;

            Console.WriteLine("PLEASE READ THE EDIT OPTIONS BELOW AND ENTER YOUR SELECTION: ");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("1. Edit the name on the order");
            Console.WriteLine("2. Edit the state on the order");
            Console.WriteLine("3. Edit the product type");
            Console.WriteLine("4. Edit the total flooring area (100sq ft minimum)");
            Console.WriteLine("\nEnter 'Q' to Quit");
            string userChoice = Console.ReadLine();

            while (!isValid)
            {
                switch (userChoice)
                {
                    case "1":
                        EditNameWorkflow editNameWorkflow = new EditNameWorkflow();
                        editNameWorkflow.NewName(order);
                        isValid = true;
                        break;


                    case "2":
                        EditStateWorkflow editStateWorkflow = new EditStateWorkflow();
                        editStateWorkflow.NewState(order);
                        isValid = true;
                        break;

                    case "3":
                        EditProductWorkflow editProductWorkflow = new EditProductWorkflow();
                        editProductWorkflow.NewProduct(order);
                        isValid = true;
                        break;

                    case "4":
                        EditAreaWorkflow editAreaWorkflow = new EditAreaWorkflow();
                        editAreaWorkflow.NewArea(order);
                        isValid = true;

                        break;

                    case "Q":
                        Menu.Start();
                        break;
                }
            }
        }

        public static DateTime GetDate()
        {
            bool isValid = false;
            string format = "MMddyyyy";
            DateTime orderDate = new DateTime();
            while (!isValid)
            {
                Console.WriteLine("Please enter an order date. Format must be MMddyyyy: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out orderDate))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Order date must be in MMddyyyy format.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Menu.Start();
                }
            }
            return orderDate;
        }

        internal static string GetProduct()
        {
            Console.WriteLine("Please enter the Product Type: ");
            GetProductMenu();
            return Console.ReadLine();
        }
        public static void GetProductMenu()
        {
            string[] types = { "Carpet", "Laminate", "Tile", "Wood" };
            decimal[] squareFootCost = { 2.25M, 1.75M, 3.50M, 5.15M };
            decimal[] laborCost = { 2.10M, 2.10M, 4.15M, 4.75M };

            Console.WriteLine();
            Console.WriteLine("{0,-15} {1,6:c} {2,6:c}\n", "Product Type", "CostPerSquareFoot", "LaborCostPerSquareFoot");
            Console.WriteLine("==============================================================================");
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine("{0,-15} {1,10:c} {2,20:c}", types[i], squareFootCost[i], laborCost[i]);
            }
            Console.WriteLine();
        }

        internal static string GetStateName()
        {
            Console.WriteLine("Please enter a state: ");
            return Console.ReadLine();
        }

        public static void DisplaySingleOrderDetail(Order order)
        {
            Console.WriteLine("YOUR EDITED ORDER DETAILS ARE BELOW");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine($"Order Number: {order.OrderNumber}" + " | " + $"OrderDate: {order.OrderDate}");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateTaxData.StateName}");
            Console.WriteLine($"Tax Rate: {order.StateTaxData.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductDetail.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Square Foot: ${order.ProductDetail.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost Per Square Foot: ${order.ProductDetail.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: ${order.MaterialCost}");
            Console.WriteLine($"Labor Cost: ${order.LaborCost}");
            Console.WriteLine($"Tax: ${order.Tax}");
            Console.WriteLine($"Total: ${order.Total}");

        }

        internal static string GetArea()
        {
            Console.WriteLine("Please enter the total area you want to floor in square feet. Minimum 100 sq ft.");
            return Console.ReadLine();
        }

        public static string GetUserName()
        {
            Console.WriteLine("Please enter the customer's name: ");
            return Console.ReadLine();
        }
        public static string GetNewUserName()
        {
            Console.WriteLine("Please enter the new name: ");
            return Console.ReadLine();
        }

        public static void DisplayEditedOrderDetail(Order order)
        {
            Console.WriteLine("YOUR NEW ORDER DETAILS ARE BELOW");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine($"Order Number: {order.OrderNumber}" + " | " + $"Order Date: { order.OrderDate}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateTaxData.StateAbbreviation}");
            Console.WriteLine($"Product Type: {order.ProductDetail.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Square Foot: ${order.ProductDetail.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost Per Square Foot: ${order.ProductDetail.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: ${order.MaterialCost}");
            Console.WriteLine($"Labor: ${order.LaborCost}");
            Console.WriteLine($"Tax: ${order.Tax}");
            Console.WriteLine($"Total: ${order.Total:c}");

        }

    }
}

