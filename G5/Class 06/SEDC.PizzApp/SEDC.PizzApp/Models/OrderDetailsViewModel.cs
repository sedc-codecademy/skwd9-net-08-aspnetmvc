namespace SEDC.PizzApp.Models
{
   // A view model
   public class OrderDetailsViewModel
   {
      public int Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string FullName { get; set; }

      public string Address { get; set; }

      public long Contact { get; set; }

      public string Pizza { get; set; }

      public double Price { get; set; }

      public string GetFullName()
      {
         return FirstName + " " + LastName;
      }

      public string GetPriceRange()
      {
         if (Price > 1000)
         {
            return "$$$$";
         }
         else if (Price > 500 && Price < 1000)
         {
            return "$$$";
         }
         else if (Price > 100 && Price < 500)
         {
            return "$$";
         }
         else
         {
            return "$";
         }
      }
   }
}