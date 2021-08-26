using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels
{
    public class NewsletterSubscription
    {
        public int Id { get; set; }
        public bool IsSubscribed { get; set; }

        public virtual User User { get; set; }
    }
}
