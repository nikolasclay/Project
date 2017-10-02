using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows.OrderEdits
{
    public class EditProduct
    {
        public void NewProduct(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.ProductInfo.ProductType = ConsoleIO.GetProduct();

            manager.SaveCurrentOrder(order);
        }
    }
}
