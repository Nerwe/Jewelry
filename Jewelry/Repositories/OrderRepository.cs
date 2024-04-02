using Jewelry.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Jewelry.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public void Add(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderModel> GetByAll()
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Orders]";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderModel order = new OrderModel()
                        {
                            Id = reader[0].ToString(),
                            Date = reader[1].ToString(),
                            Payment_Method = reader[2].ToString(),
                            Cashier_Id = reader[3].ToString()
                        };
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        public IEnumerable<OrderModel> GetById(int id)
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Orders] WHERE order_id=@order_id";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderModel order = new OrderModel()
                        {
                            Id = reader[0].ToString(),
                            Date = reader[1].ToString(),
                            Payment_Method = reader[2].ToString(),
                            Cashier_Id = reader[3].ToString()
                        };
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
        public IEnumerable<OrderModel> GetByCashierId(int cashier_id)
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Orders] WHERE cashier_id=@cashier_id";
                command.Parameters.Add("@cashier_id", System.Data.SqlDbType.NVarChar).Value = cashier_id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderModel order = new OrderModel()
                        {
                            Cashier_Id = reader[0].ToString(),
                            Id = reader[1].ToString(),
                            Date = reader[2].ToString(),
                            Payment_Method = reader[3].ToString(),
                        };
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
