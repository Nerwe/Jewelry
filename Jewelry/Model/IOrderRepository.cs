using System.Collections.Generic;

namespace Jewelry.Model
{
    public interface IOrderRepository
    {
        void Add(OrderModel orderModel);
        void Edit(OrderModel orderModel);
        void Remove(int id);
        IEnumerable<OrderModel> GetById(int id);
        IEnumerable<OrderModel> GetByAll();
        IEnumerable<OrderModel> GetByCashierId(int cashier_id);
    }
}
