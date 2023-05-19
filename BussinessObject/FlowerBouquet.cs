using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BussinessObject;

namespace BusinessObject
{
    public class FlowerBouquet
    {
        public FlowerBouquet()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? FlowerBouquetID { get; set; }

       
        public int? CategoryID { get; set; }

      
        [StringLength(50)]
        public string FlowerBouquetName { get; set; }

      
        [StringLength(50)]
        public string Description { get; set; }

     
        public decimal UnitPrice { get; set; }

      
        public short UnitInStock { get; set; }

     
        public bool FlowerBouquetStatus { get; set; }

      
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
