using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditState
    {
        public void newState(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.State = ConsoleIO.GetStateName();

            manager.SaveCurrentOrder(order);
        }
    }
}
