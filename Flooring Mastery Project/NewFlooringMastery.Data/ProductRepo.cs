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

                    string lineContent = sr.ReadLine();
                    while ((lineContent = sr.ReadLine()) != null)
                    {
                        ProductDetail products = new ProductDetail();
                        string[] columns = lineContent.Split(',');


                        products.ProductType = columns[0];
                        products.CostPerSquareFoot = decimal.Parse(columns[1]);
                        products.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        dataLoad.Add(products);
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

