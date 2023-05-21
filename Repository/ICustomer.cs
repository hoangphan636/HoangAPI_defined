using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomer
    {
        List<Customer> GetCustomer();
        Customer FindCustomerById(string Email, string password);
        void SaveCustomer(Customer product);
        Customer checkAdminLogin(string email, string password);
        Customer FindCustomerById(int id);

        void UpdateCustomer(Customer Customer);
        void DeleteCustomer(Customer Customer);
        Customer FindCustomerByEmail(string email);
    }
}
