using BusinessObject;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {

        public static List<OrderDetail> GetOrderDetail()
        {
            var list = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.OrderDetail.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static List<OrderDetail> FindFlowerBouquetById(int id)
        {
            var list = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.OrderDetail.Where(x => x.OrderID == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }






    }
}
