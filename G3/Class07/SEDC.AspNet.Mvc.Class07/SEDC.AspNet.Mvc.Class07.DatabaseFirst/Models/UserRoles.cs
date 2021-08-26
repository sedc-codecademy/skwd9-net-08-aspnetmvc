using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SEDC.AspNet.Mvc.Class07.DatabaseFirst.Models
{
    public partial class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int Id { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
