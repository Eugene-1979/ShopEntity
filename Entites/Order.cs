using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class Order
        {
        public int OrderId { get; set; }


       public Employee Employee { get; set; }
        public int ?EmployeeId { get; set; }

        public DateTime MyDate { get; set; }
        public Customer Customer{ get; set; }
        public int ?CustomerId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();



        }
    }
