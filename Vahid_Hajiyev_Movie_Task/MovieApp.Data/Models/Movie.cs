namespace MovieApp.Data.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public string LongDescription { get; set; }

        public string ReleaseYear { get; set; }

        public Genre Genre { get; set; }
    }
}
