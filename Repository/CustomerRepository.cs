using BussinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : ICustomer
    {
        public Customer checkAdminLogin(string email, string password) => CustomerDAO.checkAdminLogin(email, password);


        public Customer FindCustomerById(string Email, string password)=> CustomerDAO.FindCustomerById( Email, password);



        public List<Customer> GetCustomer() => CustomerDAO.GetCustomer();

        public void SaveCustomer(Customer product)=> CustomerDAO.SaveCustomer( product);
        
    }
}
