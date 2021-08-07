using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataAccessModels
{
    //[Table(nameof(Address))]
    public class Address
    {
        //[Key]
        public int Id { get; set; }
        //[MaxLength(50)]
        public string Name { get; set; }

        //[ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
