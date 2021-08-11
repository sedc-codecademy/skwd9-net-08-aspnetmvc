using SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.ViewModels
{
    public class UserDetailsVM
    {
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; } // Fullname
        
        [Display(Name = "Phone number")]
        public long Phone { get; set; }

        [Display(Name = "Full Address")]
        public string Address { get; set; }

        [Display(Name = "Active subscription")]
        public string IsSubscribed { get; set; }

        public UserDto UserDetails { get; set; }
    }
}
