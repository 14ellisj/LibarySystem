namespace Media_Service.Models
{
    public class MediaFilter
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public bool? IsSelected { get; set; }
        public bool? IsAvailable { get; set; }
        public int? ProfileId { get; set; }
    }
}
