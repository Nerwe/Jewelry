using Jewelry.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Jewelry.Repositories
{
    public class OrderProductRepository : RepositoryBase, IOrderProductRepository
    {
        public void Add(OrderProductModel orderProductModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderProductModel orderProductModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProductModel> GetByAll()
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "EXEC GetOrderProducts;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderProductModel orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Name = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString(),
                            Order_Date = reader[4].ToString(),
                            Cashier = reader[5].ToString(),
                            Store_Name = reader[6].ToString(),
                            Store_Address = reader[7].ToString()
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }

            return orderProducts;
        }

        public IEnumerable<OrderProductModel> GetByOrderCashierId(int id)
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "EXEC GetOrderProductsByOrderCashierId @cashier_id=@id;";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderProductModel orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Name = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString(),
                            Order_Date = reader[4].ToString(),
                            Cashier = reader[5].ToString(),
                            Store_Name = reader[6].ToString(),
                            Store_Address = reader[7].ToString()
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }

            return orderProducts;
        }

        public IEnumerable<OrderProductModel> GetByOrderId(int id)
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "EXEC GetOrderProductsByOrderId @order_id=@id;";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderProductModel orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Name = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString(),
                            Order_Date = reader[4].ToString(),
                            Cashier = reader[5].ToString(),
                            Store_Name = reader[6].ToString(),
                            Store_Address = reader[7].ToString()
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }

            return orderProducts;
        }

        public IEnumerable<OrderProductModel> GetByOrderStoreId(int id)
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "EXEC GetOrderProductsByOrderStoreId @store_id=@id;";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderProductModel orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Name = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString(),
                            Order_Date = reader[4].ToString(),
                            Cashier = reader[5].ToString(),
                            Store_Name = reader[6].ToString(),
                            Store_Address = reader[7].ToString()
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }

            return orderProducts;
        }

        public IEnumerable<OrderProductModel> GetByOrderDate(string date_t)
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "EXEC GetOrderProductsByOrderDate @date=@date_t;";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = date_t;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderProductModel orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Name = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString(),
                            Order_Date = reader[4].ToString(),
                            Cashier = reader[5].ToString(),
                            Store_Name = reader[6].ToString(),
                            Store_Address = reader[7].ToString()
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }

            return orderProducts;
        }
    }
}
