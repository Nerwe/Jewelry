using System.Collections.Generic;

namespace Jewelry.Model
{
    public interface IOrderRepository
    {
        void Add(OrderModel orderModel);
        void Edit(OrderModel orderModel);
        void Remove(int id);
        OrderModel GetById(int id);
        OrderModel GetByCashierId(int cashier_id);
        IEnumerable<OrderModel> GetByAll();
    }
}
