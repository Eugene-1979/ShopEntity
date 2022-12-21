using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class Employee
        {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }=new HashSet<Order>();
        }
    }
