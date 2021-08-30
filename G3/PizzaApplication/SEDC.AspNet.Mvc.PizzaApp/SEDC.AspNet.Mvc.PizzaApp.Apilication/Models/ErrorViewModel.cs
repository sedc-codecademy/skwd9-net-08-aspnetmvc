using System;

namespace SEDC.AspNet.Mvc.PizzaApp.Apilication.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
