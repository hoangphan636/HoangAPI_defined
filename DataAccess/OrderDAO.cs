using BusinessObject;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        CustomerDAO cus = new CustomerDAO();
        public static List<Order> GetOrder()
        {
            var list = new List<Order>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Order.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

 

        public static void SaveOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Order.Add(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      

        public static Order FindOrderById(int id)
        {
            var list = new Order();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Order.FirstOrDefault(x => x.OrderID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public static List<Order> FindOrderCustomerByEmail(int id)
        {
            
            var list = new List<Order>();
           
            try
            {
                
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Order.Where(x => x.CustomerID == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }



        public static void UpdateOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Order.Update(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Order.Remove(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }





    }
}
