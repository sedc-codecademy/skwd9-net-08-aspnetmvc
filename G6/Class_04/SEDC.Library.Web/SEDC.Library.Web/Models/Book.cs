namespace SEDC.Library.Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishingHouseId { get; set; }

        public string GetBookFullName()
        {
            return Id + " - " + Title;
        }
    }
}
