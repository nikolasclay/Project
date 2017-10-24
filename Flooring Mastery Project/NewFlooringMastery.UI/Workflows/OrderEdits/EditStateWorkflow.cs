using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditStateWorkflow
    {
        public void NewState(Order order)
        {
            bool isValid = false;
            OrderManager manager = OrderManagerFactory.Create();
            while (!isValid)
            {
                string stateName = ConsoleIO.GetStateName();
                Console.WriteLine($"Is this the correct new state: {stateName}, Y/N?");
                string correctState = Console.ReadLine().ToUpper();
                if(correctState == "Y")
                {
                    isValid = true;
                }
            }
            GetStateResponse response = new GetStateResponse();

            if (response.Success)
            {
                manager.SaveCurrentOrder(order);
                ConsoleIO.DisplayEditedOrderDetail(order);
            }
            else
            {
                response.Success = false;
                response.Message = "An error occurred: ";
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
