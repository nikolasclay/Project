using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class MockOrderRepo : IOrderRepo
    {
        private List<Order> orderList = new List<Order>();
        public Order AddOrder(Order order)
        {
            Order mockOrder = new Order()
            {
                OrderNumber = "1",
                OrderDate = new DateTime(1984, 1, 10),
                CustomerName = "Wise",
                State = "MI",
                ProductType = "Carpet",
                MaterialCost = 1000.00M,
                LaborCost = 1500.00M,
                Tax = 50.00M,
                Total = 2550.00M
            };
            orderList.Add(order);
            return mockOrder;

        }

        public List<Order> AddOrder(string fileDateTime)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrderById(string orderID, string OrderDate = null)
        {
            Order mockOrder = new Order()
            {
                OrderNumber = "1",
                OrderDate = new DateTime(1984, 1, 10),
                CustomerName = "Wise",
                State = "MI",
                ProductType = "Carpet",
                MaterialCost = 1000.00M,
                LaborCost = 1500.00M,
                Tax = 50.00M,
                Total = 2550.00M
            };
            return mockOrder;
        }

        public List<Order> LoadOrders()
        {
            if (orderList.Count == 0)
            {
                Order mockOrder = new Order()
                {
                    OrderNumber = "1",
                    OrderDate = new DateTime(1984, 1, 10),
                    CustomerName = "Wise",
                    State = "MI",
                    ProductType = "Carpet",
                    MaterialCost = 1000.00M,
                    LaborCost = 1500.00M,
                    Tax = 50.00M,
                    Total = 2550.00M
                };
                orderList.Add(mockOrder);
            }

            return orderList;
        }

        public List<Order> LoadOrders(string fileDateTime, string userName)
        {
            orderList = new List<Order>();

            Order mockOrder = new Order()
            {
                OrderNumber = "1",
                OrderDate = new DateTime(1984, 1, 10),
                CustomerName = "Wise",
                State = "MI",
                ProductType = "Carpet",
                MaterialCost = 1000.00M,
                LaborCost = 1500.00M,
                Tax = 50.00M,
                Total = 2550.00M
            };
            orderList.Add(mockOrder);

            return orderList;
        }

        public Order OverwriteOrder(Order order)
        {
            orderList = new List<Order>();

            Order mockOrder = new Order()
            {
                OrderNumber = "1",
                OrderDate = new DateTime(1984, 1, 10),
                CustomerName = "Wise",
                State = "MI",
                ProductType = "Carpet",
                MaterialCost = 1000.00M,
                LaborCost = 1500.00M,
                Tax = 50.00M,
                Total = 2550.00M
            };
            orderList.Add(mockOrder);

            return mockOrder;
        }

        public bool RemoveOrder(string orderID, string OrderDate)
        {
            return true;
        }
    }
}
