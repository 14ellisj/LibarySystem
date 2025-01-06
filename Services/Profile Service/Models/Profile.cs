using System.Text.Json.Serialization;

namespace Profile_Service.Models
{
    public class UserProfile
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("role")]
        public Role Role { get; set; }
        [JsonPropertyName("library")]
        public Library Library { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
