using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Order> orders)
        {
            foreach(Order order in orders)
            {
                Console.WriteLine("*************************************");
                Console.WriteLine(order.OrderNumber + "|" + order.OrderDate);
                Console.WriteLine(order.CustomerName);
                Console.WriteLine(order.State);
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine("*************************************");
            }

        }

        public static DateTime ValidateDate()
        {
            bool isValid = false;
            string format = "MMddyyyy";
            DateTime orderDate = new DateTime();
            while (!isValid)
            {
                Console.WriteLine("Please enter an order date. Format must be MMddyyyy: ");
                string input = Console.ReadLine();

                if(DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out orderDate))
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
        public static string GetUserName()
        {
            Console.WriteLine("Please enter customer name: ");
            return Console.ReadLine();
        }
        

    }
}
