using System;
using System.Collections.Generic;
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
        public int? ShopId { get; set; }
        public ICollection<Product> Products { get; set; }
        }
    }
