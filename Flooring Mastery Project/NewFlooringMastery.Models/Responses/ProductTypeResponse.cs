using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Responses;

namespace NewFlooringMastery.BLL
{
    public class ProductTypeResponse : Response
    {
        public ProductDetail ProductType { get; set; }
    }
}