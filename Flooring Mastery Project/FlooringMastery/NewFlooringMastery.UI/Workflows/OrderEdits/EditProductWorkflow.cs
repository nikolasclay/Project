using NewFlooringMastery.BLL;
using NewFlooringMastery.Data;
using NewFlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditProductWorkflow
    {
        bool isValid = false;
        public void NewProduct(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();
            while (!isValid)
            {
                ProductRepo repo = new ProductRepo();
                string productType = ConsoleIO.GetProduct(repo.LoadProducts());
                Console.WriteLine($"Is this the correct new product: {productType}, Y/N?");
                string correctProduct = Console.ReadLine().ToUpper();
                if(correctProduct == "Y")
                {
                 
                    isValid = true;
                }
                ProductTypeResponse response = manager.FindProductByType(productType);
                if (response.Success)
                {
                    manager.SaveCurrentOrder(order);
                    ConsoleIO.DisplayEditedOrderDetail(order);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    response.Success = false;
                    response.Message = "An error occurred";
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
