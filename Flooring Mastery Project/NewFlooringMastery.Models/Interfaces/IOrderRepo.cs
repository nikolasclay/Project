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
        Order LoadOrder(DateTime orderDate, int orderNumber);

        bool RemoveOrder(Order order);

        bool SaveCurrentOrder(Order order);

        bool SaveNewOrder(Order order);
    }
}
