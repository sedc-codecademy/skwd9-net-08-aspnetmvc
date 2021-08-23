using System;

namespace SEDC.PizzaApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        //public DateTime CreateDate { get; set; }//10:40 //10:40
        //public DateTime ModifiedAt { get; set; }//10:40 //10:45 // 10:50 
    }
}
