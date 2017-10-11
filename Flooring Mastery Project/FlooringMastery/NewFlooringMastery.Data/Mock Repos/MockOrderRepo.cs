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
        private List<Order> _orders = new List<Order>()
        {
            new Order
            {
                OrderNumber = "1",
                OrderDate = new DateTime(1984, 01, 10),
                CustomerName = "Clay",

            }
        };
        public List<Order> LoadAllOrders(DateTime orderDate)
        {
            List<Order> mockOrder = new List<Order>();

            foreach (var order in _orders)
            {
                if (order.OrderDate == orderDate)
                {
                    mockOrder.Add(order);
                }
            }
            return mockOrder;
        }

        public Order LoadOrder(DateTime orderDate, string orderNumber)
        {
            List<Order> orders = LoadAllOrders(orderDate);
            if (orders == null || orders.Count == 0)
            {
                return null;
            }
            else
            {
                Order order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                return order;
            }

        }

        public bool RemoveOrder(Order order)
        {
            var result = _orders.RemoveAll(m => m.OrderNumber == order.OrderNumber);
            //_orders.Remove(order);
            return result > 0;
        }

        public bool SaveCurrentOrder(Order order)
        {
            //if (order.OrderNumber == "0")
            //{
            //    SaveNewOrder(order);
            //}
            //else
            //{
            //    _orders.Add(order);

            //}
            return true;
        }

        public bool SaveNewOrder(Order order)
        {
            //_orders.Add(order);
            return true;
        }

    }
}




