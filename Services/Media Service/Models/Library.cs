using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class Library
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
