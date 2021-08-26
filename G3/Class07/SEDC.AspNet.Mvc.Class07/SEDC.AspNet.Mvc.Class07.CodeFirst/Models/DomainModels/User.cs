using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public int AddressId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual NewsletterSubscription Subscription { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
