using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class OrderDetail
    {
      
        public int OrderID { get; set; }

      
        public int FlowerBouquetID { get; set; }

     
        public decimal UnitPrice { get; set; }

       
        public int Quantity { get; set; }

        
        public int Discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual FlowerBouquet FlowerBouquet { get; set; }
    }
}
