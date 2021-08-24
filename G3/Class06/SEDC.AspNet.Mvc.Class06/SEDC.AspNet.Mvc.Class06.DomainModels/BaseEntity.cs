using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainModels
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
