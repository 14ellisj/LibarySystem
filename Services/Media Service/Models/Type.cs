namespace Media_Service.Models
{
    public class Type
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
    }
}
