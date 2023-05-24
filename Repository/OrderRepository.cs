using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order Order)=>OrderDAO.DeleteOrder(Order);
      

        public Order FindOrderById(int id) => OrderDAO.FindOrderById( id);

        public List<Order> FindOrderCustomerByEmail(int id) => OrderDAO.FindOrderCustomerByEmail(id);



        public List<Order> GetOrder() => OrderDAO.GetOrder();
     

        public void SaveOrder(Order Order) => OrderDAO.SaveOrder( Order);


        public void UpdateOrder(Order Order) => OrderDAO.UpdateOrder( Order);

    }
}
