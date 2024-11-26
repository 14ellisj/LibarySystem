using Media_Service.Database;
using System.Text.Json.Serialization;

namespace Media_Service.Models
{

    public class Author
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        public Author()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
