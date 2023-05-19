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
    public class Category
    {


        public Category()
        {
            FlowerBouquets = new HashSet<FlowerBouquet>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CategoryID { get; set; }
       
        [StringLength(50)]
        public string CategoryName { get; set; }
       
        [StringLength(50)]
        public string CategoryDescription { get; set; }


        public virtual ICollection<FlowerBouquet> FlowerBouquets { get; set; }
    }
}
