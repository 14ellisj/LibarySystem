using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class Media
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("author")]
        public Author Author { get; set; }
        [JsonPropertyName("type")]
        public MediaType Type { get; set; }
        [JsonPropertyName("genre")]
        public Genre Genre { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
         public string Description { get; set; }
         [JsonPropertyName("rating")]
         public int Rating { get; set; }
        
    }
}
