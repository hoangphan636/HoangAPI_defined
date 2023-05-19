using BussinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomer()
        {
            var list = new List<Customer>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Customer.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Customer FindCustomerById(string Email, string password)
        {
            var list = new Customer();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Customer.FirstOrDefault(x => x.Email == Email && x.password==password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void SaveCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Customer.Add(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static Customer checkAdminLogin(string email, string password)
        {
            var c = new FUFlowerSystemDbContext();
            Customer admin = c.getDefaultAccounts();
            if (email == admin.Email && password == admin.password)
            {
                return admin;
            }
            return null;
        }

        public static Customer FindCustomerById(int id)
        {
            var list = new Customer();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Customer.FirstOrDefault(x => x.CustomerID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void UpdateCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Customer.Update(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.Customer.Remove(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
