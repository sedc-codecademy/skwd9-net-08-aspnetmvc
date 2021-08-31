using SEDC.PizzaApp.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnPromotion { get; set; }
        public double Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public string Image { get; set; }
    }
}
