using Jewelry.Model;
using Jewelry.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jewelry.ViewModel
{
    public class AnalyzeViewModel : ViewModelBase
    {
        //Fields
        private ComboBoxRepository _comboBoxRepository;

        private string _tableName;
        private string _fieldName;
        private string _fieldValue;
        private string _fieldData;

        private ObservableCollection<string> _tableNames;
        private ObservableCollection<string> _fieldNames;
        private ObservableCollection<string> _fieldValues;
        private ObservableCollection<string> _fieldDatas;

        private ObservableCollection<OrderProductModel> _orderProducts;
        private OrderProductRepository _orderProductRepository;

        private ObservableCollection<ProductModel> _products;
        private ProductRepository _productRepository;

        private ObservableCollection<OrderModel> _orders;
        private OrderRepository _orderRepository;

        //Properties
        public string TableName
        {
            get => _tableName;
            set
            {
                _tableName = value;
                OnPropertyChanged(nameof(TableName));
            }
        }
        public string FieldName
        {
            get => _fieldName;
            set
            {
                _fieldName = value;
                OnPropertyChanged(nameof(FieldName));
            }
        }
        public string FieldValue
        {
            get => _fieldValue;
            set
            {
                _fieldValue = value;
                OnPropertyChanged(nameof(FieldValue));
            }
        }
        public string FieldData
        {
            get => _fieldData;
            set
            {
                _fieldData = value;
                OnPropertyChanged(nameof(FieldData));
            }
        }
        public ObservableCollection<string> TableNames
        {
            get => _tableNames;
            set
            {
                _tableNames = value;
                OnPropertyChanged(nameof(TableNames));
            }
        }
        public ObservableCollection<string> FieldNames
        {
            get => _fieldNames;
            set
            {
                _fieldNames = value;
                OnPropertyChanged(nameof(FieldNames));
            }
        }
        public ObservableCollection<string> FieldValues
        {
            get => _fieldValues;
            set
            {
                _fieldValues = value;
                OnPropertyChanged(nameof(FieldValues));
            }
        }
        public ObservableCollection<string> FieldDatas
        {
            get => _fieldDatas;
            set
            {
                _fieldDatas = value;
                OnPropertyChanged(nameof(FieldDatas));
            }
        }

        public ObservableCollection<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public ObservableCollection<OrderModel> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        public ObservableCollection<OrderProductModel> OrderProducts
        {
            get => _orderProducts;
            set
            {
                _orderProducts = value;
                OnPropertyChanged(nameof(OrderProducts));
            }
        }

        //Commands /*ComboBox*/
        public ICommand ShowFieldNamesCommand { get; }
        public ICommand ShowFieldValuesCommand { get; }
        public ICommand ShowFieldDatasCommand { get; }

        //Commands /*OrderProducts*/
        public ICommand ShowOrderProductsCommand { get; }
        public ICommand ShowOrderProductsByOrderIdCommand { get; }
        public ICommand ShowOrderProductsByOrderDateCommand { get; }
        public ICommand ShowOrderProductsByOrderStoreIdCommand { get; }
        public ICommand ShowOrderProductsByOrderCashierIdCommand { get; }

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
            _comboBoxRepository = new ComboBoxRepository();
            _productRepository = new ProductRepository();
            _orderRepository = new OrderRepository();
            _orderProductRepository = new OrderProductRepository();

            //Initialize Lists
            TableNames = new ObservableCollection<string>(_comboBoxRepository.GetAllTableNames());
            FieldNames = new ObservableCollection<string>();
            FieldValues = new ObservableCollection<string>();
            FieldDatas = new ObservableCollection<string>();
            OrderProducts = new ObservableCollection<OrderProductModel>();
            Orders = new ObservableCollection<OrderModel>();
            Products = new ObservableCollection<ProductModel>();

            //Initialize commands /*ComboBox*/
            ShowFieldNamesCommand = new ViewModelCommand(ExecuteShowFieldNamesCommand);
            ShowFieldValuesCommand = new ViewModelCommand(ExecuteShowFieldValuesCommand);
            ShowFieldDatasCommand = new ViewModelCommand(ExecuteShowFieldDatasCommand);

            //Initialize commands /*OrderProducts*/
            ShowOrderProductsCommand = new ViewModelCommand(ExecuteShowOrderProductsCommand);
            ShowOrderProductsByOrderIdCommand = new ViewModelCommand(ExecuteShowOrderProductsByOrderIdCommand);
            ShowOrderProductsByOrderDateCommand = new ViewModelCommand(ExecuteShowOrderProductsByOrderDateCommand);
            ShowOrderProductsByOrderStoreIdCommand = new ViewModelCommand(ExecuteShowOrderProductsByOrderStoreIdCommand);
            ShowOrderProductsByOrderCashierIdCommand = new ViewModelCommand(ExecuteShowOrderProductsByOrderCashierIdCommand);

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


        //Execute commands /*ComboBox*/

        private void ExecuteShowFieldNamesCommand(object obj)
        {
            if (TableName != null)
            {
                FieldNames.Clear();
                var fieldList = _comboBoxRepository.GetAllFieldsOfTable(TableName);
                foreach (var field in fieldList)
                {
                    FieldNames.Add(field);
                }
            }
        }
        private void ExecuteShowFieldValuesCommand(object obj)
        {
            if (TableName != null && FieldName != null)
            {
                FieldValues.Clear();
                var valueList = _comboBoxRepository.GetAllValuesOfField(TableName, FieldName);
                foreach (var value in valueList)
                {
                    FieldValues.Add(value);
                }
            }
        }
        private void ExecuteShowFieldDatasCommand(object obj)
        {
            if (TableName != null && FieldName != null && FieldValue != null)
            {
                FieldDatas.Clear();
                var valueList = _comboBoxRepository.GetDataByFieldValue(TableName, FieldName, FieldValue);
                foreach (var value in valueList)
                {
                    FieldDatas.Add(value);
                }
            }
        }

        //Execute commands /*OrderProducts*/
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
        private void ExecuteShowOrderProductsByOrderDateCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByOrderDate("2023-01-01");
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }
        private void ExecuteShowOrderProductsByOrderStoreIdCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByOrderStoreId(2);
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }
        private void ExecuteShowOrderProductsByOrderCashierIdCommand(object obj)
        {
            OrderProducts.Clear();

            var orderProductList = _orderProductRepository.GetByOrderCashierId(2);
            foreach (var orderProduct in orderProductList)
            {
                OrderProducts.Add(orderProduct);
            }
        }

        //Execute commands /*Order*/
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

        //Execute commands /*Products*/
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
