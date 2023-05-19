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

        public void DeleteCustomer(Customer Customer) => CustomerDAO.DeleteCustomer( Customer);



        public Customer FindCustomerById(string Email, string password)=> CustomerDAO.FindCustomerById( Email, password);

        public Customer FindCustomerById(int id) => CustomerDAO. FindCustomerById( id);


        public List<Customer> GetCustomer() => CustomerDAO.GetCustomer();

        public void SaveCustomer(Customer product)=> CustomerDAO.SaveCustomer( product);

        public void UpdateCustomer(Customer Customer) => CustomerDAO.UpdateCustomer( Customer);

    }
}
