namespace API_Gateway
{

    public class Media
    {
        public Author author { get; set; }
        public Type type { get; set; }
        public Genre genre { get; set; }
        public string name { get; set; }
    }

    public class Author
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public enum Type
    {
        AUDIO_BOOK,
        BOOK,
        DVD
    }

    public enum Genre
    {
        FANTASY,
        ROMANCE,
        CRIME
    }
}
