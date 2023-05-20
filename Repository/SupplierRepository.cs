using BussinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public List<Supplier> GetSupplier() => SupplierDAO.GetSupplier();
       
    }
}
