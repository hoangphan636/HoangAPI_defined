using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISupplierRepository
    {
        List<Supplier> GetSupplier();
    }
}
