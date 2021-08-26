using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SEDC.AspNet.Mvc.Class07.DatabaseFirst.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
