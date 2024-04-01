using System.Collections.Generic;

namespace Jewelry.Model
{
    public interface IProductRepository
    {
        void Add(ProductModel productModel);
        void Edit(ProductModel productModel);
        void Remove(int id);
        ProductModel GetById(int id);
        ProductModel GetByName(string name);
        IEnumerable<ProductModel> GetByAll();
    }
}
