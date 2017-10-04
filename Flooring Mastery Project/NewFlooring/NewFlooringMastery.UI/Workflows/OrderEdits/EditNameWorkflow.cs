using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditNameWorkflow
    {
        bool isValid = false;
        public void NewName(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();
            while (!isValid)
            {
                order.CustomerName = ConsoleIO.GetNewUserName();
                Console.WriteLine($"Is this the correct name:{order.CustomerName}, Y/N?");
                string correctName = Console.ReadLine().ToUpper();
                if (correctName == "Y")
                {
                    isValid = true;
                }
            }
            manager.SaveCurrentOrder(order);
            ConsoleIO.DisplayEditedOrderDetail(order);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
