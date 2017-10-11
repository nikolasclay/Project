using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using System;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{

    public class EditAreaWorkflow
    {
        bool isValid = false;
        internal void NewArea(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();
            while (!isValid)
            {
                string newArea = ConsoleIO.GetArea();
                Console.WriteLine($"Is this the correct area: {newArea}square feet, Y/N?");
                string correctArea = Console.ReadLine().ToUpper();
                if (correctArea == "Y")
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

