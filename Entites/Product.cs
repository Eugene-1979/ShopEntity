﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity.Entites
    {
    public class Product
        {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int? Sale { get; set; }
       


      public Category Category{ get; set; }
        
public int? CategoryId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }



        }
    }
