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

        public IEnumerable<OrderProductModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public OrderProductModel GetByOrderId(int id)
        {
            OrderProductModel orderProduct = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [OrderProducs] WHERE [order_id]=@id";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orderProduct = new OrderProductModel()
                        {
                            Order_Id = reader[0].ToString(),
                            Product_Id = reader[1].ToString(),
                            Quantity = reader[2].ToString(),
                            Price = reader[3].ToString()
                        };
                    }
                }
            }

            return orderProduct;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
