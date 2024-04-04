using Jewelry.Model;
using System;
using System.Collections.Generic;

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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderModel> GetByCashierId(int cashier_id)
        {
            throw new NotImplementedException();
        }
    }
}
