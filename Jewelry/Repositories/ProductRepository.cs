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

        public ProductModel GetById(int id)
        {
            ProductModel product = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Products] WHERE [product_id]=@id";
                command.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new ProductModel()
                        {
                            Id = reader[0].ToString(),
                            Name = reader[1].ToString(),
                            Category_Id = reader[2].ToString(),
                            Metal_Id = reader[3].ToString(),
                            Size_Id = reader[4].ToString(),
                            Price = reader[5].ToString()
                        };
                    }
                }
            }

            return product;
        }

        public ProductModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
