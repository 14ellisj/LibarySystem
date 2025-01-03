using System.Text.Json.Serialization;

namespace Profile_Service.Models
{
    public class RegisterDetails
    {
        [JsonPropertyName("email")]
        public string? email { get; set; }
        [JsonPropertyName("first_name")]
        public string? firstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? lastName { get; set; }
        [JsonPropertyName("password")]
        public string? password { get; set; }
    }
}