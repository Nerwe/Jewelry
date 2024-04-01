using System.Collections.Generic;

namespace Jewelry.Model
{
    public interface IOrderProductRepository
    {
        void Add(OrderProductModel orderProductModel);
        void Edit(OrderProductModel orderProductModel);
        void Remove(int id);
        OrderProductModel GetByOrderId(int id);
        IEnumerable<OrderProductModel> GetByAll();
    }
}
