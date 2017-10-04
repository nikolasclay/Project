using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFlooringMastery.Models;
using System.IO;

namespace NewFlooringMastery.Data
{
    public class ProductRepo : IProductRepo
    {
        Dictionary<string, ProductDetail> productCollection;
        public const string filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\Products.txt";



        public ProductRepo()
        {
            productCollection = LoadProducts().ToDictionary(p => p.ProductType);
        }

        private List<ProductDetail> LoadProducts()
        {
            List<ProductDetail> dataLoad = new List<ProductDetail>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {

                    sr.ReadLine();
                    string line = String.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ProductDetail productInfo = new ProductDetail();
                        string[] columns = line.Split(',');


                        productInfo.ProductType = columns[0];
                        productInfo.CostPerSquareFoot = decimal.Parse(columns[1]);
                        productInfo.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        dataLoad.Add(productInfo);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataLoad;
        }
        public ProductDetail FindProductByType(string productType)
        {
            if (productCollection.ContainsKey(productType))
            {
                return productCollection[productType];
            }
            else
            {
                return null;
            }
        }

        public ProductDetail GetProduct(string productType)
        {
            throw new NotImplementedException();
        }
    }
}

