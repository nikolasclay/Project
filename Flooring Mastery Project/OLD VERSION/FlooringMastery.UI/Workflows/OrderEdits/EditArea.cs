using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditArea
    {
        internal void NewArea(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.Area = decimal.Parse(ConsoleIO.GetArea());

            manager.SaveCurrentOrder(order);
        }

    }
}
