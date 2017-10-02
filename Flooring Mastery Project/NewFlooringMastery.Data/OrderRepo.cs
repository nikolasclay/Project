using NewFlooringMastery.Models.Interfaces;
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
        TaxRepo taxRepo = new TaxRepo();
        ProductDetail productRepo = new ProductDetail();

        //public Order AddOrder(Order order)
        //{
        //    string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
        //    string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;

        //    List<Order> orders = new List<Order>();

        //    if (File.Exists(fileFullName))
        //    //if file exists. Append
        //    {
        //        orders = LoadOrdersFromFile(fileFullName);
        //        if (orders.Count() == 0)
        //        {
        //            order.OrderNumber = "1";
        //        }
        //        else
        //        {
        //            var maxID = orders.Max(o => o.OrderNumber);
        //            order.OrderNumber = (int.Parse(maxID) + 1).ToString();

        //        }
        //        orders.Add(order);
        //    }
        //    var saveOrderResult = SaveNewOrder(order);
        //    if (saveOrderResult)
        //    {
        //        return order;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        private List<Order> LoadOrdersFromFile(string fileFullName)
        {
            List<Order> returnValue = new List<Order>();
            if (File.Exists(fileFullName))
            {

                using (StreamReader reader = new StreamReader(fileFullName))
                {
                    reader.ReadLine();
                    string line = String.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        {
                            string[] columns = line.Split(',');
                            Order order = new Order()
                            {
                                OrderNumber = columns[0],

                            };
                            if (columns.Length > 5)
                            {
                                order.CustomerName = columns[1] + "," + columns[2];
                                order.State = columns[3];
                                order.StateTaxRate = taxRepo.LoadTaxForState(columns[4]);
                                order.ProductInfo.ProductType = columns[5];
                                order.Area = decimal.Parse(columns[6]);
                                //order.ProductInfo.CostPerSquareFoot = decimal.Parse(columns[7]);
                                //order.ProductInfo.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                                //order.MaterialCost = decimal.Parse(columns[9]);
                                //order.LaborCost = decimal.Parse(columns[10]);
                                //order.Tax = decimal.Parse(columns[11]);
                                //order.Total = decimal.Parse(columns[12]);
                            }
                            else
                            {
                                order.CustomerName = columns[1];
                                order.State = columns[2];
                                order.StateTaxRate = taxRepo.LoadTaxForState(columns[3]);
                                order.ProductInfo.ProductType = columns[4];
                                order.Area = decimal.Parse(columns[5]);
                                //order.CostPerSquareFoot = decimal.Parse(columns[6]);
                                //order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                                //order.MaterialCost = decimal.Parse(columns[8]);
                                //order.LaborCost = decimal.Parse(columns[9]);
                                //order.Tax = decimal.Parse(columns[10]);
                                //order.Total = decimal.Parse(columns[11]);
                            }
                            returnValue.Add(order);
                        }
                    }
                    reader.Close();
                }
                return returnValue;
            }
            else
            {
                return null;
            }
        }
        public List<Order> LoadOrders(string fileDateTime)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(string orderID, string OrderDate)
        {
            throw new NotImplementedException();
        }

        public bool SaveCurrentOrder(Order order)
        {
            string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            List<Order> orderList = LoadOrdersFromFile(order.OrderDate.ToString("MMddyyyy"));
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
                        sw.WriteLine($"{saveOrder.OrderNumber}, " +
                            $"{saveOrder.CustomerName}, " +
                            $"{saveOrder.State}, " +
                            $"{saveOrder.StateTaxRate}, " +
                            $"{saveOrder.ProductInfo.ProductType}, " +
                            $"{saveOrder.Area}, " +
                            $"{saveOrder.ProductInfo.CostPerSquareFoot}, " +
                            $"{saveOrder.ProductInfo.LaborCostPerSquareFoot}, " +
                            $"{saveOrder.MaterialCost}, " +
                            $"{saveOrder.LaborCost}, " +
                            $"{saveOrder.Tax}, " +
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
            List<Order> orderList = LoadOrdersFromFile(order.OrderDate.ToString("MMddyyyy"));
            string fileName = "Orders_" + order.OrderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;

            if (File.Exists(fileFullName))
            //if file exists. Append
            {
                orderList = LoadOrdersFromFile(fileFullName);
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
                        sw.WriteLine($"{newOrder.OrderNumber}, " +
                            $"{newOrder.CustomerName}, " +
                            $"{newOrder.State}, " +
                            $"{newOrder.StateTaxRate}, " +
                            $"{newOrder.ProductInfo.ProductType}, " +
                            $"{newOrder.Area}, " +
                            $"{newOrder.ProductInfo.CostPerSquareFoot}, " +
                            $"{newOrder.ProductInfo.LaborCostPerSquareFoot}, " +
                            $"{newOrder.MaterialCost}, " +
                            $"{newOrder.LaborCost}, " +
                            $"{newOrder.Tax}, " +
                            $"{newOrder.Total}");
                    }
                }
            }
            return true;
        }
        public Order LoadOrder(DateTime orderDate, string orderNumber)
        {
            string fileName = "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            var allOrder = LoadOrdersFromFile(fileFullName);
            var singleOrder = allOrder.SingleOrDefault(o => o.OrderNumber == orderNumber);

            return singleOrder;
        }

        public List<Order> LoadAllOrders(DateTime orderDate)
        {
            string fileName = "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            var allOrder = LoadOrdersFromFile(fileFullName);

            return allOrder;
        }
    }
}
