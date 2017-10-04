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

        public LookupOrderResponse LookupOrder(DateTime orderDate)
        {
            LookupOrderResponse response = new LookupOrderResponse();

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
            else
            {
                response.Success = true;
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
        public RemoveOrderResponse RemoveOrder(Order order)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.Success = _orderRepository.RemoveOrder(order);
            if (response.Success == false)
            {
                response.Message = ($"{order} does not exist!");
            }
            return response;

        }

        public ProductTypeResponse FindProductByType(string productType)
        {
            ProductTypeResponse response = new ProductTypeResponse();
            response.ProductType = _productRepository.FindProductByType(productType);
            if (response.ProductType == null)
            {
                response.Success = false;
                response.Message = ($"{productType} does not exist!");
            }
            else
            {
                response.Success = true;
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
                response.Message = $"{stateAbbreviation} is not valid!";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}

