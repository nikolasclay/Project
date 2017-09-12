using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise6();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filtered = DataLoader.LoadProducts().Where(p => p.UnitsInStock <= 0);
            PrintProductInformation(filtered);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var filtered = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.0000M);
            PrintProductInformation(filtered);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var filtered = DataLoader.LoadCustomers().Where(c => c.Region == "WA");
            PrintCustomerInformation(filtered);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {

            var products = from p in DataLoader.LoadProducts()
                           select new { ProductName = p.ProductName };
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }


        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               ProductID = p.ProductID,
                               ProductName = p.ProductName,
                               Category = p.Category,
                               UnitPrice = p.UnitPrice * 1.25M,
                               UnitsInStock = p.UnitsInStock,
                           };


            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock);
            }


        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            string lineFormat = "{0,-35}{1,-35}";

            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               ProductName = p.ProductName.ToUpper(),
                               Category = p.Category.ToUpper(),
                           };
            foreach(var product in products)
            {
                Console.WriteLine(lineFormat, product.ProductName, product.Category);

            }
    
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            string lineFormat = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}{5,6}";
            bool Reorder= false;
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               ProductID = p.ProductID,
                               ProductName = p.ProductName,
                               Category = p.Category,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock,
                               Reorder = (p.UnitsInStock < 3),
                           };
            foreach (var product in products)
            {
                Console.WriteLine(lineFormat, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.Reorder);

            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            string lineFormat = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,12:c}";
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               ProductID = p.ProductID,
                               ProductName = p.ProductName,
                               Category = p.Category,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock,
                               StockValue = p.UnitsInStock * p.UnitPrice,
                           };
            foreach (var product in products)
            {
                Console.WriteLine(lineFormat, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.StockValue);

            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {

            var nums = from n in DataLoader.NumbersA
                       where n % 2 == 0
                       select n;
            foreach (var evenNums in nums)
            {
                Console.WriteLine(evenNums);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var orders = DataLoader.LoadCustomers().Where(c => c.Orders.Any(oo => oo.Total < 500));
            PrintCustomerInformation(orders);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var nums = (from n in DataLoader.NumbersC
                        where n % 2 == 1
                        select n).Take(3);
            foreach (var evenNums in nums)
            {
                Console.WriteLine(evenNums);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var nums = (from n in DataLoader.NumbersB
                        select n).Skip(3);
            foreach (var evenNums in nums)
            {
                Console.WriteLine(evenNums);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            string lineFormat = "{0,-35}{1,-35}";
            var name = from c in DataLoader.LoadCustomers().Where(c => c.Region == "WA")
                       select new { CompanyName = c.CompanyName, OrderDate = c.Orders.OrderByDescending(o => o.OrderDate).First() };
            foreach (var input in name)
            {
                Console.WriteLine(lineFormat, input.CompanyName, input.OrderDate.OrderID);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbers = (from n in DataLoader.NumbersC.TakeWhile(n => n <= 6)
                        select n);
            foreach (var nums in numbers)
            {
                Console.WriteLine(nums);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbers = (from n in DataLoader.NumbersC.SkipWhile(n => n%3 !=0)
                select n).Skip(1);
            foreach (var oddNums in numbers)
            {
                Console.WriteLine(oddNums);
            }
            

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
          
            var filtered = from p in DataLoader.LoadProducts().OrderBy(p => p.ProductName)
                           select p;
            PrintProductInformation(filtered);

        }
        

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
           
            var filtered = from p in DataLoader.LoadProducts()
                           orderby p.UnitsInStock descending               
                           select p;
            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var filtered = from p in DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p=> p.UnitPrice)
                           select p;
            PrintProductInformation(filtered);

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var nums = (from n in DataLoader.NumbersB.Reverse()
                        select n);
            foreach (var evenNums in nums)
            {
                Console.WriteLine(evenNums);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {

            var groups = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Key);
                Console.WriteLine("--------------------------------------------");

                foreach (var product in group)
                {
                    Console.WriteLine(product.ProductName);
                    Console.WriteLine();
                }

            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var groups = DataLoader.LoadProducts().GroupBy(g => g.Category);

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Key);

            }


        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var results = DataLoader.LoadProducts().Any().Equals("789");
            Console.WriteLine(results);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

            var groups = DataLoader.LoadProducts().Where(p => p.UnitsInStock <= 0).GroupBy(g => g.Category);

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Key);

            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

            var groups = DataLoader.LoadProducts().GroupBy(g => g.Category).Where(g => g.All(p=> p.UnitsInStock > 0));

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Key);

            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var nums = (from n in DataLoader.NumbersA
                        where n % 2 == 1
                        select n).Count();
            Console.WriteLine(nums);

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = (from c in DataLoader.LoadCustomers()
                            select new
                            {
                                CustomerID = c.CustomerID,
                                Order = c.Orders.Count()
                            });
           foreach(var customer in customers)
            {
                Console.WriteLine("Customer ID: {0}",customer.CustomerID);
                Console.WriteLine("Order Count: {0}",customer.Order);
                Console.WriteLine();
            }
            

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

            var groups = from p in DataLoader.LoadProducts()
                         group p by p.Category into newGroup
                         select new
                         {
                             Category = newGroup.Key,
                             ProductCount = newGroup.Count()
                         };

                foreach (var group in groups)
                {
                    Console.WriteLine("Category: {0}", group.Category);
                    Console.WriteLine("Product Count: {0}", group.ProductCount);
                    Console.WriteLine();
                  
                }

        }

        

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var groups = from g in DataLoader.LoadProducts()
                         group g by g.Category into newGroup
                         select new
                         {
                             Category = newGroup.Key,
                             TotalUnits = newGroup.Sum(g => g.UnitsInStock)
                         };
           
            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Category);
                Console.WriteLine("Total Units: {0}", group.TotalUnits);
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            String line = "{0, -35}{1, -30}";
            Console.WriteLine(line, "Category", "Lowest Unit Price");





            var groups = from n in DataLoader.LoadProducts().OrderBy(u => u.UnitPrice).GroupBy(c => c.Category)
                         select new
                         {
                             Category = n.Key,
                             MinUnit = n.First().UnitPrice,
                             ProductName = n.First().ProductName,
                          };

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Category);
                Console.WriteLine("Product: {0}", group.ProductName);
                Console.WriteLine("Total Units: {0}", group.MinUnit);
                Console.WriteLine();

            }
        }
    

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var groups = (from g in DataLoader.LoadProducts()
                          group g by g.Category into newGroup

                          select new
                          {
                              Category = newGroup.Key,
                              AvgUnit = newGroup.Average(g => g.UnitPrice),
                            
                          }).OrderByDescending(g=> g.AvgUnit).Take(3);

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Category);
                Console.WriteLine("Average Unit Price: {0}", group.AvgUnit);
                Console.WriteLine();

            }
        }
    }
}
