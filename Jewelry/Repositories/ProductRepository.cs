using Jewelry.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Jewelry.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public void Add(ProductModel productModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProductModel productModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetById(int id)
        {
            List<ProductModel> products = new List<ProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Products] WHERE product_id=@id";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductModel product = new ProductModel()
                        {
                            Id = reader[0].ToString(),
                            Name = reader[1].ToString(),
                            Category_Id = reader[2].ToString(),
                            Metal_Id = reader[3].ToString(),
                            Size_Id = reader[4].ToString(),
                            Price = reader[5].ToString(),
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public IEnumerable<ProductModel> GetByName(string name)
        {
            List<ProductModel> products = new List<ProductModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Products] WHERE name=@name";
                command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductModel product = new ProductModel()
                        {
                            Name = reader[0].ToString(),
                            Id = reader[1].ToString(),
                            Category_Id = reader[2].ToString(),
                            Metal_Id = reader[3].ToString(),
                            Size_Id = reader[4].ToString(),
                            Price = reader[5].ToString(),
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
