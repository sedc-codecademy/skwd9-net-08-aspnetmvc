using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SEDC.Library.Web.Models
{
    public class Book
    {
        [DisplayName("Identifier")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishingHouseId { get; set; }

        public string GetBookFullName()
        {
            return Id + " - " + Title;
        }
    }
}
