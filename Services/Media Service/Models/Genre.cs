using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public int Name { get; set; }
    }
}