﻿using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFlooringMastery.Models;
using System.Configuration;
using System.IO;

namespace NewFlooringMastery.Data
{
    public class OrderRepo : IOrderRepo
    {
        StateTaxRepo stateTaxRepo = new StateTaxRepo();
        ProductRepo productRepo = new ProductRepo();

         public List<Order> LoadOrders(string fileDateTime)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(Order order)
        {
            List<Order> orderList = new List<Order>();
            string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            var allOrder = LoadAllOrders(order.OrderDate);

            try
            {
                using (StreamWriter sw = new StreamWriter(fileFullName))
                {
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    foreach (var orderChoice in orderList)
                    {
                        Order singleOrder = new Order();
                        if (singleOrder.OrderNumber == order.OrderNumber)
                        {
                            orderList.Remove(singleOrder);
                        }
                        else
                        {
                            sw.WriteLine($"{singleOrder.OrderNumber}," +
                            $"{singleOrder.CustomerName}," +
                            $"{singleOrder.State}," +
                            $"{singleOrder.StateTaxData.TaxRate}," +
                            $"{singleOrder.ProductDetail.ProductType}," +
                            $"{singleOrder.Area}," +
                            $"{singleOrder.CostPerSquareFoot}," +
                            $"{singleOrder.LaborCostPerSquareFoot}," +
                            $"{singleOrder.MaterialCost}," +
                            $"{singleOrder.LaborCost}," +
                            $"{singleOrder.Tax}," +
                            $"{singleOrder.Total}");
                        }
                    }  
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCurrentOrder(Order order)
        {
            string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            List<Order> orderList = LoadAllOrders(order.OrderDate);
            try
            {
                using (StreamWriter sw = new StreamWriter(fileFullName))
                {
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                    foreach (var currentOrder in orderList)
                    {
                        Order saveOrder = currentOrder;
                        if (saveOrder.OrderNumber == order.OrderNumber)
                        {
                            saveOrder = order;
                        }
                        sw.WriteLine($"{saveOrder.OrderNumber}," +
                            $"{saveOrder.CustomerName}," +
                            $"{saveOrder.State}," +
                            $"{saveOrder.StateTaxData.TaxRate}," +
                            $"{saveOrder.ProductDetail.ProductType}," +
                            $"{saveOrder.Area}," +
                            $"{saveOrder.CostPerSquareFoot}," +
                            $"{saveOrder.LaborCostPerSquareFoot}," +
                            $"{saveOrder.MaterialCost}," +
                            $"{saveOrder.LaborCost}," +
                            $"{saveOrder.Tax}," +
                            $"{saveOrder.Total}");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveNewOrder(Order order)
        {
            List<Order> orderList = LoadAllOrders(order.OrderDate);
            string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;

                if (orderList.Count() == 0)
                {
                    order.OrderNumber = "1";
                }
                else
                {
                    var maxID = orderList.Max(o => o.OrderNumber);
                    order.OrderNumber = (int.Parse(maxID) + 1).ToString();

                }
                orderList.Add(order);


                using (StreamWriter sw = new StreamWriter(fileFullName))
                {
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    foreach (var newOrder in orderList)
                    {
                        Order newSaveOrder = newOrder;
                        sw.WriteLine($"{newSaveOrder.OrderNumber}," +
                            $"{newSaveOrder.CustomerName}," +
                            //$"{newOrder.State}, " +
                            $"{newSaveOrder.State}," +
                            $"{newSaveOrder.StateTaxData.TaxRate}," + 
                            $"{newSaveOrder.ProductDetail.ProductType}," +
                            $"{newSaveOrder.Area}," +
                            $"{newSaveOrder.ProductDetail.CostPerSquareFoot}," +
                            $"{newSaveOrder.ProductDetail.LaborCostPerSquareFoot}," +
                            $"{newSaveOrder.MaterialCost}," +
                            $"{newSaveOrder.LaborCost}," +
                            $"{newSaveOrder.Tax}," +
                            $"{newSaveOrder.Total}");
                    }
            }
            return true;
        }
        public Order LoadOrder(DateTime orderDate, string orderNumber)
        {
            string fileName = "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            var allOrder = LoadAllOrders(orderDate);
            var singleOrder = allOrder.SingleOrDefault(o => o.OrderNumber == orderNumber);

            return singleOrder;
        }

        public List<Order> LoadAllOrders(DateTime orderDate)
        {
            string fileName = "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            List<Order> returnValue = new List<Order>();

            if (File.Exists(fileFullName))
            {

                using (StreamReader reader = new StreamReader(fileFullName))
                {
                    reader.ReadLine();
                    string line = String.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        Order order = new Order();
                        order.OrderDate = orderDate;
                        {

                            order.OrderNumber = columns[0];
                            order.CustomerName = columns[1];
                            //order.State = columns[2];
                            order.StateTaxData = stateTaxRepo.LoadTaxForState(columns[4]);
                            order.ProductDetail = productRepo.FindProductByType(columns[4]);
                            order.Area = decimal.Parse(columns[5]);
                        }
                        returnValue.Add(order);
                    }
                }
            }
            return returnValue;
        }

        public bool RemoveOrder(DateTime orderDate, string orderNumber)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
