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


        [StringLength(50, ErrorMessage = "The length  50 chara ")]
        public string FlowerBouquetName { get; set; }


        [StringLength(50, ErrorMessage = "The length  50 chara ")]
        public string Description { get; set; }

        [Range(1, 4000, ErrorMessage ="1 den 4000")]
        public decimal UnitPrice { get; set; }

        [Range(1, 50000, ErrorMessage = "1 den 50000")]
        public short UnitInStock { get; set; }

     
        public bool FlowerBouquetStatus { get; set; }

      
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
