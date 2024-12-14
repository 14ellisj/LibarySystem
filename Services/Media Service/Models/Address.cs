using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class Address
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public int HouseNumber {get; : set;}
        public string StreetName { get; : set; }
        public string City { get; : set; }
        public string County { get; : set; }
        public string Postcode { get; : set; }
    }
}