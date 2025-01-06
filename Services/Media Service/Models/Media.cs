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
        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("length")]
        public string Length { get; set; }
        [JsonPropertyName("rating")]
        public string Rating { get; set; }
        [JsonPropertyName("is_borrowed_by_user")]
        public bool IsBorrwedByUser { get; set; }
        [JsonPropertyName("is_reserved_by_user")]
        public bool IsReservedByUser { get; set; }
        [JsonPropertyName("reserveQueue")]
        public string reserveQueue { get; set; }
    }
}
