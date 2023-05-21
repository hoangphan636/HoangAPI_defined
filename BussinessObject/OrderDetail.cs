using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class OrderDetail
    {
      
        public int OrderID { get; set; }

      
        public int FlowerBouquetID { get; set; }

        [Range(1, 2000000, ErrorMessage = "1 between 2000000")]
        public decimal UnitPrice { get; set; }

        [Range(1, 200, ErrorMessage = "1 between 200")]
        public int Quantity { get; set; }

        [Range(1, 50, ErrorMessage = "1 between 50")]
        public int Discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual FlowerBouquet FlowerBouquet { get; set; }
    }
}
