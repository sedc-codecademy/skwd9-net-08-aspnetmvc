

using SEDC.PizzaApp.Domain.Enums;

namespace SEDC.PizzaApp.Domain.Models
{
    public class PizzaOrder : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public PizzaSizeEnum PizzaSize { get; set; }
    }
}
