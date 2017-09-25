using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Requests;
using FlooringMastery.Models.Responses;
using System;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepo _orderRepository;
        private ITaxRepo _taxRepository;
        private IProductsRepo _productsRepository;

        public OrderManager(IOrderRepo orderRepository, ITaxRepo taxRespository, IProductsRepo productsRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRespository;
            _productsRepository = productsRepository;
        }

        public DisplayOrderResponse DisplayOrders(DateTime orderDate, string customerName)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Orders = _orderRepository.LoadOrders(orderDate.ToString("MMddyyyy"), customerName);
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
        public AddEditOrderResponse AddOrder(AddEditOrderRequest request)
        {
            AddEditOrderResponse response = new AddEditOrderResponse();
            response.Order = _orderRepository.AddOrder(request.Order, request.FileDateTime);
            if(response.Order == null)
            {
                response.Success = false;
                response.Message = ($"{request.Order} does not exist!");
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public AddEditOrderResponse EditOrder(AddEditOrderRequest request)
        {
            AddEditOrderResponse response = new AddEditOrderResponse();
            response.Order = _orderRepository.OverwriteOrder(request.Order);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = ($"{request.Order} does not exist!");
            }
            else
            {
                response.Success = true;
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
    }
}
