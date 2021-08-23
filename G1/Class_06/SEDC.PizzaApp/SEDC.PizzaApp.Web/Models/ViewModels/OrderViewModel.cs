using SEDC.PizzaApp.Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Name of pizza")]
        public string PizzaName { get; set; }
        public string PizzaStore { get; set; }
        public double Price { get; set; }
        public bool Delivered { get; set; }
        //public string UserFullName { get; set; }//user.FirstName + user.LastName
        public int UserId { get; set; }
    }
}
