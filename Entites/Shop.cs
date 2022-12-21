using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class Shop
        {    
        [Key]
        public int ShopId { get; set; }
        public string Name { get; set; }
        public virtual List<Category> Categorys { get; set; }=new List<Category>();
        }
 
    }

