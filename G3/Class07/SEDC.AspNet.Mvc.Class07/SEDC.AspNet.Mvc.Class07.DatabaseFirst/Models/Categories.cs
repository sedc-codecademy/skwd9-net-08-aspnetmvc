using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SEDC.AspNet.Mvc.Class07.DatabaseFirst.Models
{
    public partial class Categories
    {
        public Categories()
        {
            SubCategories = new HashSet<SubCategories>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategories> SubCategories { get; set; }
    }
}
