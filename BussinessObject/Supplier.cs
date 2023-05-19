using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace BussinessObject
{
    public class Supplier
    {

        public Supplier()
        {
            FlowerBouquets = new HashSet<FlowerBouquet>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SupplierID { get; set; }
     
        [StringLength(50)]
        public string SupplierName { get; set; }
      
        [StringLength(50)]
        public string SupplierAddress { get; set; }
     
        [StringLength(50)]
        public string telephone { get; set; }


        public virtual ICollection<FlowerBouquet> FlowerBouquets { get; set; }
    }
}
