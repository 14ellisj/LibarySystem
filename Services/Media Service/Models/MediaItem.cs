namespace Media_Service.Models
{
    public class MediaItem
    {
        public int Id { get; set; }
        public Media Media { get; set; }
        public User? Borrower {  get; set; }
        public User? Reserver {  get; set; }
        public Library Library { get; set; }
    }
}
