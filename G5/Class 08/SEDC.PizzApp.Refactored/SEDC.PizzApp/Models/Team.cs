using System.Collections.Generic;

namespace SEDC.PizzApp.Refactored.Models
{
   public class Team
   {
      public int TeamId { get; set; }

      public string Name { get; set; }

      public List<Player> Players { get; set; }

      public int League { get; set; }
   }
}