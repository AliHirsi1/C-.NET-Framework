using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring;
using Flooring.Models.Responses;
using Flooring.Models.Repo;

namespace Flooring.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IStateTaxRepository _taxRepository;
        private IProductRepository _productRepository;


        public List<Order> AllOrders(DateTime date)
        {
            return _orderRepository.FindOrders(date);
        }

        // create constructor
        public OrderManager(IOrderRepository orderRepository, IStateTaxRepository taxRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRepository;
            _productRepository = productRepository;
        }



        public Order GetOrder(int orderNumber)
        {
            return _orderRepository.GetOrder(orderNumber);
        }


        // Display Order Response
        public DisplayOrderResponse DisplayOrders(DateTime orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();
            response.Orders = _orderRepository.FindOrders(orderDate);
            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} is invalid OrderDate";
            }

            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddOrderResponse AddOrder(Order order)
        {
            string firstPath = "Orders_";
            string fileFormat = ".txt";

            string createFilePath = firstPath + order.Date.ToShortDateString() + fileFormat;
            string filePath = @"C:\Users\Guild\FlooringMastery\ProductionFiles" + createFilePath;

            AddOrderResponse response = new AddOrderResponse();

            response.Order = _orderRepository.AddOrder(order);

            //var repository = _orderRepository;
            DateTime orderDate = DateTime.MinValue;
            var orders = _orderRepository.FindOrders(orderDate);

            var tax = _taxRepository.GetAllStateTax();

            var product = _productRepository.AllProducts();

            var rate = string.Empty;
            var productType = string.Empty;



            response.Success = true;

            try
            {
                int counter = 0;
                if (orders.Count == 0)
                {

                    order.OrderNumber = 1;
                }
                else
                {
                    counter = orders.Max(o => o.OrderNumber) + 1;
                }

                var taxes = tax.First(t => t.StateAbbreviation == order.StateAbbreviation);
                order.TaxRate = taxes.TaxRate;

                var products = product.First(p => p.ProductType == order.ProductType);

                order.CostPerSquareFoot = products.CostPerSquareFoot;
                order.LaborCostPerSquareFoot = products.LaborCostPerSquareFoot;

                orders.Add(order);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message} Can't add order. See Add Order Method";
            }



            return response;







        }


        public EditOrderResponse EditOrder(Order order, DateTime orderDate, int OrderNumber)
        {
            // AddOrderResponse response = new AddOrderResponse();
            EditOrderResponse response = new EditOrderResponse();

            var orders = _orderRepository.FindOrders(orderDate);

            var tax = _taxRepository.GetAllStateTax();

            var product = _productRepository.AllProducts();

            try
            {

                var taxes = tax.First(t => t.StateAbbreviation == order.StateAbbreviation);
                order.TaxRate = taxes.TaxRate;

                var products = product.First(p => p.ProductType == order.ProductType);

                order.CostPerSquareFoot = products.CostPerSquareFoot;
                order.LaborCostPerSquareFoot = products.LaborCostPerSquareFoot;

                _orderRepository.EditOrder(order);


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{ex.Message} Can't add order. See Add Order Method";
            }

            return response;
        }


        public RemoveOrderResponse RemoveOrder(DateTime date, int orderNumber)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            var orders = _orderRepository.FindOrders(date);


            response.Success = true;
            var filter = orders.SingleOrDefault(a => a.OrderNumber != orderNumber);

            if (filter != null)
            {
                _orderRepository.RemoveOrder(filter);
            }
            else
            {
                response.Success = false;
                response.Message = "No order was removed";
            }

            return response;

        }

        

        public ProductLookupResponse LookupProduct(string productType)
        {
            ProductLookupResponse response = new ProductLookupResponse();

            response.Product = _productRepository.LoadProducts(productType);

            if (response.Product == null)
            {
                response.Success = false;
                response.Message = $"{productType} is invalid product type";
            }
            else
            {
                response.Success = true;
            }

            return response;


        }

        public StateLookupResponse LookupState(string stateName)
        {
            StateLookupResponse response = new StateLookupResponse();
            response.Tax = _taxRepository.LoadStateTax(stateName);
            if (response.Tax == null)
            {
                response.Success = false;
                response.Message = $"{stateName} is innvalid state";
            }

            else
            {
                response.Success = true;

            }

            return response;
        }






    }

}

