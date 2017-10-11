using NewFlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "TestMode":
                    return new OrderManager(new MockOrderRepo(), new MockTaxRepo(), new MockProductRepo());

                case "ProdMode":
                    return new OrderManager(new OrderRepo(), new StateTaxRepo(), new ProductRepo());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
