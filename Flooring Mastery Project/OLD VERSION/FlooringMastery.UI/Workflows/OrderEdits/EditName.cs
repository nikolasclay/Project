using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditName
    {
        public void NewName(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.CustomerName = ConsoleIO.GetUserName();

            manager.SaveCurrentOrder(order);
        }
    }
}
