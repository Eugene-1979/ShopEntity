﻿namespace ShopEntity.Entites
    {
    public class Customer
        {
        public int CustomerId { get; set; }
        public string Name { get; set; }


       
        public ICollection<Order> Orders { get; set; }

        }
    }
