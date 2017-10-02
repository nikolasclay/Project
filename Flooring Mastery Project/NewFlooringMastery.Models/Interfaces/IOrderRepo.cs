using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models.Interfaces
{
    public interface IOrderRepo
    {
        List<Order> LoadAllOrders(DateTime orderDate);
        Order LoadOrder(DateTime orderDate, string orderNumber);

        bool RemoveOrder(string orderID, string OrderDate);

        bool SaveCurrentOrder(Order order);

        bool SaveNewOrder(Order order);
    }
}
