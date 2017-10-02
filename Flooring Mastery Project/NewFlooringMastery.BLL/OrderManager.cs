using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Interfaces;
using NewFlooringMastery.Models.Requests;
using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepo _orderRepository;
        private ITaxRepo _taxRepository;
        private IProductRepo _productRepository;

        public OrderManager(IOrderRepo orderRepository, ITaxRepo taxRespository, IProductRepo productRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRespository;
            _productRepository = productRepository;
        }

        public DisplayOrderResponse DisplayOrder(DateTime orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Orders = _orderRepository.LoadAllOrders(orderDate);
            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = ($"{orderDate} does not exist!");
            }
            else
            {
                response.Success = true;
            }
            return response;

        }

        public LoadOrderResponse LoadRequestedOrder(DateTime orderDate, string orderNumber)
        {
            LoadOrderResponse response = new LoadOrderResponse();

            response.Order = _orderRepository.LoadOrder(orderDate, orderNumber);
            if(response.Order == null)
            {
                response.Success = false;
                response.Message = ($"{orderDate} does not exist!");
            }
            return response;
        }


        public SaveCurrentOrderResponse SaveCurrentOrder(Order order)
        {
            SaveCurrentOrderResponse response = new SaveCurrentOrderResponse();
            response.Success = _orderRepository.SaveCurrentOrder(order);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = ($"{order} does not exist!");
            }
            return response;
        }
        public SaveNewOrderResponse SaveNewOrder(Order order)
        {
            SaveNewOrderResponse response = new SaveNewOrderResponse();
            response.Success = _orderRepository.SaveNewOrder(order);
            if(response.Order == null)
            {
                response.Success = false;
                response.Message = ($"{order} does not exist!");
            }
            return response;
        }
        public RemoveOrderResponse RemoveOrder(RemoveOrderRequest request)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.Success = _orderRepository.RemoveOrder(request.OrderID, request.OrderFileName);
            if (!response.Success)
            {
                response.Message = ($"{request.OrderID} does not exist!");
            }
            return response;
        }

        public ProductTypeResponse FindProductByType(string productType)
        {
            ProductTypeResponse response = new ProductTypeResponse();
            response.ProductTypeInfo = _productRepository.FindProductByType(productType);
            if (!response.Success)
            {
                response.Message = ($"{productType} does not exist!");
            }
            return response;
        }
        public GetStateResponse GetStateTaxData(string stateAbbreviation)
        {
            GetStateResponse response = new GetStateResponse();

            response.TaxData = _taxRepository.LoadTaxForState(stateAbbreviation);

            if(response.TaxData == null)
            {
                response.Success = false;
            }
            return response;
        }
    }
}

