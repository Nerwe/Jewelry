using Jewelry.Model;
using Jewelry.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Jewelry.ViewModel
{
    public class OrdersViewModel : ViewModelBase
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

        //Commands
        public ICommand ShowOrderCommand { get; }
        public ICommand ShowProductCommand { get; }
        public ICommand ShowOrderProductCommand { get; }

        public OrdersViewModel()
        {
            _productRepository = new ProductRepository();
            _orderRepository = new OrderRepository();
            _orderProductRepository = new OrderProductRepository();

            //Initialize commands
            ShowOrderCommand = new ViewModelCommand(ExecuteShowOrderCommand);
            ShowProductCommand = new ViewModelCommand(ExecuteShowProductCommand);
            ShowOrderProductCommand = new ViewModelCommand(ExecuteShowOrderProductCommand);

            //Default view
            ExecuteShowOrderProductCommand(null);
        }

        private void ExecuteShowOrderProductCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByAll();
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }

        private void ExecuteShowProductCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteShowOrderCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
