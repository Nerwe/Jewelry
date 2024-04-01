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
            throw new NotImplementedException();
        }

        public OrderModel GetByCashierId(int cashier_id)
        {
            throw new NotImplementedException();
        }

        public OrderModel GetById(int id)
        {
            OrderModel order = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Orders] WHERE [order_id]=@id";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new OrderModel()
                        {
                            Id = reader[0].ToString(),
                            Date = reader[1].ToString(),
                            Payment_Method = reader[2].ToString(),
                            Cashier_Id = reader[3].ToString()
                        };
                    }
                }
            }

            return order;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
