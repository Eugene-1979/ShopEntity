using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class OrderProduct
        {
      


        public Order Order { get; set; }
       
        public int OrderId { get; set; }

        public int Amount{ get; set; }

        public Product Product { get; set; }
     
        public int ProductId { get; set; }
        }
    }
