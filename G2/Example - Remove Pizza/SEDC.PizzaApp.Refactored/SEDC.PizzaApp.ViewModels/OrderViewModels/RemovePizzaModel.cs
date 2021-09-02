using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class RemovePizzaModel
    {
        //the order we remove from
        public int OrderId { get; set; }
        //the pizza we will remove
        [Display(Name ="Pizza")]
        public int PizzaId { get; set; }
    }
}
