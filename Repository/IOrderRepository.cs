using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrder();
        void SaveOrder(Order Order);
        Order FindOrderById(int id);
        void UpdateOrder(Order Order);
        void DeleteOrder(Order Order);

    }
}
