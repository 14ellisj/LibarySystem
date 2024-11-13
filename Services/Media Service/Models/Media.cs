namespace Media_Service.Models
{
    public class Media
    {
        public Author author { get; set; }
        public MediaType type { get; set; }
        public Genre genre { get; set; }
        public string name { get; set; }
    }
}
