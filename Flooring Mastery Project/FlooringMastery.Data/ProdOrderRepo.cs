using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;
using System.Configuration;

namespace FlooringMastery.Data
{
    public class ProdOrderRepo : IOrderRepo
    {
        public Order AddOrder(Order order, string fileDateTime)
        {
            string fileName = "Orders_" + fileDateTime + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            List<Order> orders = new List<Order>();
            if (File.Exists(fileFullName))
            //if file exists. Append
            {
                orders = LoadOrdersFromFile(fileFullName);
                var maxID = orders.Max(o => o.OrderNumber);
                order.OrderNumber = (int.Parse(maxID) + 1).ToString();
                orders.Add(order);

            }
            //file doesn't exist. Create file.
            else
            {
                order.OrderNumber = "1";
                orders.Add(order);

            }
            var saveOrderResult = SaveOrders(orders, fileFullName);
            if (saveOrderResult)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        private bool SaveOrders(List<Order> orders, string fileFullName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileFullName, true))
                {
                    foreach (var order in orders)
                    {
                        string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
                        sw.WriteLine(line);
                    }
                    sw.Flush();
                    sw.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        private List<Order> LoadOrdersFromFile(string fileName)
        {
            List<Order> returnValue = new List<Order>();
            if (File.Exists(fileName))
            {

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line = String.Empty;
                    bool firstLine = true;
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (firstLine)
                        {
                            firstLine = false;
                            continue;
                        }
                        if (line != null)
                        {
                            string[] columns = line.Split(',');
                            Order order = new Order()
                            {
                                OrderNumber = columns[0],

                            };
                            if (columns.Length > 12)
                            {
                                order.CustomerName = columns[1] + "," + columns[2];
                                order.State = columns[3];
                                order.TaxRate = decimal.Parse(columns[4]);
                                order.ProductType = columns[5];
                                order.Area = decimal.Parse(columns[6]);
                                order.CostPerSquareFoot = decimal.Parse(columns[7]);
                                order.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                                order.MaterialCost = decimal.Parse(columns[9]);
                                order.LaborCost = decimal.Parse(columns[10]);
                                order.Tax = decimal.Parse(columns[11]);
                                order.Total = decimal.Parse(columns[12]);
                            }
                            else
                            {
                                order.CustomerName = columns[1];
                                order.State = columns[2];
                                order.TaxRate = decimal.Parse(columns[3]);
                                order.ProductType = columns[4];
                                order.Area = decimal.Parse(columns[5]);
                                order.CostPerSquareFoot = decimal.Parse(columns[6]);
                                order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                                order.MaterialCost = decimal.Parse(columns[8]);
                                order.LaborCost = decimal.Parse(columns[9]);
                                order.Tax = decimal.Parse(columns[10]);
                                order.Total = decimal.Parse(columns[11]);
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

        public List<Order> LoadOrders(string fileDateTime, string customerName)
        {
            string fileName = "Orders_" + fileDateTime + ".txt";
            string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;
            var orders = LoadOrdersFromFile(fileFullName);
            if (orders == null)
            {
                return null;
            }
            else
            {
                return orders.Where(c => c.CustomerName.ToUpper() == customerName.ToUpper()).ToList();
            }

        }

        //private void CreateOrderFile(List<Order> orders, string filedatetime)
        //{
        //    string filename = "orders_" + filedatetime + ".txt";
        //    string filefullname = ConfigurationManager.AppSettings["filelocation"] + "\\" + filename;

        //    if (File.Exists(filefullname))
        //    {
        //        File.Delete(filefullname);
        //    }

        //    using (StreamWriter sw = new StreamWriter(filefullname))
        //    {
        //        sw.WriteLine("order number", "customer name", "state", "tax rate", "producttype", "area", "costpersqaurefoot", "laborcostpersquarefoot", "materialcost", "laborcost", "tax", "total");
        //        foreach (var order in orders)
        //        {
        //            sw.WriteLine(CreateOrderFile(order, filedatetime));
        //        }
        //    }
        //}

        //public Order EditOrder(Order order, string fileDateTime, int orderNumber)
        //{
        //    string fileName = "Orders_" + fileDateTime + ".txt";
        //    string fileFullName = ConfigurationManager.AppSettings["FileLocation"] + "\\" + fileName;

        //    if (File.Exists(fileFullName))
        //    {
        //        var orders = LoadOrdersFromFile(fileFullName);
        //    }
        //    else
        //    {

        //    }
        //}
        public bool RemoveOrder(string orderID, string OrderDate)
        {
            return true;
        }

        public List<Order> LoadOrders()
        {
            throw new NotImplementedException();
        }

        public Order LoadOrderById(string orderID, string OrderDate = null)
        {
            throw new NotImplementedException();
        }

        public Order OverwriteOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
