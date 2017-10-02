using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepo
    {
        List<Order> LoadOrders();
        List<Order> LoadOrders(string fileDateTime, string customerName);
        Order LoadOrderById(string orderID, string OrderDate = null);

        Order AddOrder(Order order);

        Order OverwriteOrder(Order order);

        bool RemoveOrder(string orderID, string OrderDate);
    }

}
