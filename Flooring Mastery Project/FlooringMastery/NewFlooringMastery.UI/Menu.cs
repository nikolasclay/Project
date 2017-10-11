using NewFlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI
{
    class Menu
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("* Flooring Mastery Project *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine("1. Display Order: ");
            Console.WriteLine("2. Add New Order: ");
            Console.WriteLine("3. Edit Order: ");
            Console.WriteLine("4. Remove Order: ");
            Console.WriteLine("\nQ to quit: ");
            Console.WriteLine("\nPlease enter selection: ");

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case "1":
                    DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                    displayWorkflow.Execute();
                    break;
                case "2":
                    AddNewOrderWorkflow addWorkflow = new AddNewOrderWorkflow();
                    addWorkflow.Execute();
                    break;

                case "3":
                    EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                    editWorkflow.Execute();
                    break;

                case "4":
                    RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                    removeWorkflow.Execute();
                    break;

                case "Q":
                    return;
            }

        }
    }
}

