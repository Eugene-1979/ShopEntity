using System.ComponentModel.DataAnnotations;

namespace ShopEntity.Entites
    {
    public class Customer
        {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }


       
        public virtual ICollection<Order> Orders { get; set; }=new List<Order>();

        }
    }
