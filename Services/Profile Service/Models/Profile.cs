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
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("DOB")]
        public string DateOfBirth { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
