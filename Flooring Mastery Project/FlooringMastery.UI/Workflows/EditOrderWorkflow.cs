using FlooringMastery.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    class EditOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Edit an order");
            Console.WriteLine("----------------------------");
        }
    }
}
