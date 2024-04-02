using Jewelry.Model;
using Jewelry.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Jewelry.ViewModel
{
    public class AnalyzeViewModel : ViewModelBase
    {
        //Fields
        private List<ProductModel> _products;
        private ProductRepository _productRepository;

        private List<OrderModel> _orders;
        private OrderRepository _orderRepository;

        private List<OrderProductModel> _orderProducts;
        private OrderProductRepository _orderProductRepository;

        //Properties
        public List<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public List<OrderModel> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        public List<OrderProductModel> OrderProducts
        {
            get => _orderProducts;
            set
            {
                _orderProducts = value;
                OnPropertyChanged(nameof(OrderProducts));
            }
        }

        //Commands /*OrderProducts*/
        public ICommand ShowOrderProductsCommand { get; }
        public ICommand ShowOrderProductsByOrderIdCommand { get; }

        //Commands /*Orders*/
        public ICommand ShowOrderCommand { get; }
        public ICommand ShowOrderByIdCommand { get; }
        public ICommand ShowOrderByCashierIdCommand { get; }

        //Commands /*Products*/
        public ICommand ShowProductCommand { get; }
        public ICommand ShowProductByIdCommand { get; }
        public ICommand ShowProductByNameCommand { get; }

        public AnalyzeViewModel()
        {
            _productRepository = new ProductRepository();
            _orderRepository = new OrderRepository();
            _orderProductRepository = new OrderProductRepository();

            //Initialize Lists
            OrderProducts = new List<OrderProductModel>();

            //Initialize commands /*OrderProducts*/
            ShowOrderProductsCommand = new ViewModelCommand(ExecuteShowOrderProductsCommand);
            ShowOrderProductsByOrderIdCommand = new ViewModelCommand(ExecuteShowOrderProductsByOrderIdCommand);

            //Initialize commands /*Orders*/
            ShowOrderCommand = new ViewModelCommand(ExecuteShowOrderCommand);
            ShowOrderByIdCommand = new ViewModelCommand(ExecuteShowOrderByIdCommand);
            ShowOrderByCashierIdCommand = new ViewModelCommand(ExecuteShowOrderByCashierIdCommand);

            //Initialize commands /*Products*/
            ShowProductCommand = new ViewModelCommand(ExecuteShowProductCommand);
            ShowProductByIdCommand = new ViewModelCommand(ExecuteShowProductByIdCommand);
            ShowProductByNameCommand = new ViewModelCommand(ExecuteShowProductByNameCommand);

            //Default view
            ExecuteShowOrderProductsCommand(null);
        }


        private void ExecuteShowOrderProductsCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByAll();
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }
        private void ExecuteShowOrderProductsByOrderIdCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByOrderId(2);
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }

        private void ExecuteShowOrderCommand(object obj)
        {
            Orders.Clear();

            var orderList = _orderRepository.GetByAll();
            foreach (var order in orderList)
            {
                Orders.Add(order);
            }
        }
        private void ExecuteShowOrderByIdCommand(object obj)
        {
            Orders.Clear();

            var orderList = _orderRepository.GetById(1);
            foreach (var order in orderList)
            {
                Orders.Add(order);
            }
        }
        private void ExecuteShowOrderByCashierIdCommand(object obj)
        {
            Orders.Clear();

            var orderList = _orderRepository.GetByCashierId(1);
            foreach (var order in orderList)
            {
                Orders.Add(order);
            }
        }

        private void ExecuteShowProductCommand(object obj)
        {
            Products.Clear();

            var productList = _productRepository.GetByAll();
            foreach (var product in productList)
            {
                Products.Add(product);
            }
        }
        private void ExecuteShowProductByIdCommand(object obj)
        {
            Products.Clear();

            var productList = _productRepository.GetById(1);
            foreach (var product in productList)
            {
                Products.Add(product);
            }
        }
        private void ExecuteShowProductByNameCommand(object obj)
        {
            Products.Clear();

            var productList = _productRepository.GetByName("name");
            foreach (var product in productList)
            {
                Products.Add(product);
            }
        }
    }
}
