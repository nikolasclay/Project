using NewFlooringMastery.Models;
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
            foreach (Order order in orders)
            {
                Console.WriteLine("YOUR ORDER DETAILS ARE BELOW");
                Console.WriteLine("*************************************");
                Console.WriteLine(order.OrderNumber + "|" + order.OrderDate);
                Console.WriteLine(order.CustomerName);
                Console.WriteLine(order.State);
                Console.WriteLine($"Product: {order.ProductInfo.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine("*************************************");
            }
        }
        public static string GetOrderNumber()
        {
            Console.WriteLine("Please enter your choice: ");
            string userChoice = Console.ReadLine();
            return userChoice;
        }
        public static void MenuForEditOrder()
        {
            Console.WriteLine("PLEASE READ THE EDIT OPTIONS BELOW AND ENTER YOUR SELECTION: ");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("1. Edit the name on the order");
            Console.WriteLine("2. Edit the state on the order");
            Console.WriteLine("3. Edit the product type");
            Console.WriteLine("4. Edit the total flooring area (100sq ft minimum)");
            Console.WriteLine("\nEnter 'Q' to Quit");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    string getName = GetUserName();
                    Console.WriteLine($"Is this the correct name (Y/N)? : {getName}");
                    string correctName = Console.ReadLine().ToUpper();
                    if (correctName == "N")
                    {
                        GetUserName();
                    }
                    break;

                case "2":
                    string getState = GetStateName();
                    Console.WriteLine($"Is this the correct state (Y/N)? : {getState}");
                    string correctState = Console.ReadLine().ToUpper();
                    if (correctState == "N")
                    {
                        GetDate();
                    }
                    //else
                    //{
                    //    edit
                    //}
                    break;

                case "3":
                    string getProduct = GetProduct();
                    Console.WriteLine($"Is this the correct product? Y/N : {getProduct}");
                    string correctProduct = Console.ReadLine().ToUpper();
                    if (correctProduct == "N")
                    {
                        GetProduct();
                    }
                    break;

                case "4":
                    string getArea = GetArea();
                    Console.WriteLine($"Is this the correct square footage of flooring? Y/N : {getArea}");
                    string correctArea = Console.ReadLine().ToUpper();
                    if (correctArea == "N")
                    {
                        GetArea();
                    }
                    break;

                case "Q":
                    Menu.Start();
                    break;
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
            return Console.ReadLine();
        }

        internal static string GetStateName()
        {
            Console.WriteLine("Please enter a state: ");
            return Console.ReadLine();
        }

        internal static void DisplaySingleOrderDetail(Order order)
        {
            Console.WriteLine("YOUR ORDER DETAILS ARE BELOW");
            Console.WriteLine("*************************************");
            Console.WriteLine(order.OrderNumber + "|" + order.OrderDate);
            Console.WriteLine(order.CustomerName);
            Console.WriteLine(order.State);
            Console.WriteLine($"Product: {order.ProductInfo.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine("*************************************");
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

        public static void DisplayEditedOrderDetail(Order order)
        {
            Console.WriteLine("*************************************");
            Console.WriteLine(order.OrderNumber + "|" + order.OrderDate);
            Console.WriteLine(order.CustomerName);
            Console.WriteLine(order.State);
            Console.WriteLine($"Product: {order.ProductInfo.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine("*************************************");
        }
    }
}

