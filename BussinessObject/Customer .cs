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
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CustomerID { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string password { get; set; }

        public DateTime BirthDay { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
