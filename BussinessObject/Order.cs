using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BussinessObject;

namespace BusinessObject
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OrderID { get; set; }

      
        public int? CustomerID { get; set; }

       
        public DateTime OrderDate { get; set; }

       
        public DateTime ShippedDate { get; set; }


        [StringLength(50, ErrorMessage = "The length  50 chara ")]
        public string Freight { get; set; }


        [StringLength(50, ErrorMessage = "The length  50 chara ")]
        public string Total { get; set; }

      
        public bool OrderStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
