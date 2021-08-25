using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainModels.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [MaxLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
    }
}
