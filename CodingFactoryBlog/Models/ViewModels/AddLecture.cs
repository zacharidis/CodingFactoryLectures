namespace CodingFactoryBlog.Models.ViewModels
{
    public class AddLecture
    {
        public string Header { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public string UniqueUrl { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

    }
}
