using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFlooringMastery.Models;

namespace NewFlooringMastery.Data
{
    public class MockOrderRepo : IOrderRepo
    {
        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadAllOrders(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(DateTime orderDate, string orderNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadOrders(string fileDateTime)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(string orderID, string OrderDate)
        {
            throw new NotImplementedException();
        }

        public bool SaveCurrentOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool SaveNewOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
        