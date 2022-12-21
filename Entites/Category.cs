using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class Category
        {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public Shop Shop { get; set; }

     
        [ForeignKey("Shop")]
        [Column(Order=1)]
        public int? ShopId { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        }
    }
