using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.Models.DtoModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
    }
}
