namespace SEDC.AspNet.Mvc.PizzaApp.Domain.Models
{
    public class PizzaOrder : BaseEntity
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
