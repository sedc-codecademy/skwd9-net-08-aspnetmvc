using SEDC.PizzaApp.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Price
        {
            get
            {
                return PizzaOrders.Sum(x => x.Pizza.Price) + 2;
            }
        }
        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string PizzaStore { get; set; }
    }
}
