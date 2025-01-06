using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class MediaItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("media")]
        public Media Media { get; set; }
        [JsonPropertyName("borrower")]
        public User? Borrower {  get; set; }
        [JsonPropertyName("reserver")]
        public User? Reserver {  get; set; }
        [JsonPropertyName("library")]
        public Library Library { get; set; }
    }
}
