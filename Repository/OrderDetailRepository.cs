using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail FindFlowerBouquetById(int id) => OrderDetailDAO.FindFlowerBouquetById(id);
     

        public List<OrderDetail> GetOrderDetail() => OrderDetailDAO.GetOrderDetail();
      
    }
}
