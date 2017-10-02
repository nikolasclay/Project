using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Responses;

namespace NewFlooringMastery.BLL
{
    public class ProductTypeResponse : Response
    {
        public ProductDetail ProductTypeInfo { get; set; }
    }
}