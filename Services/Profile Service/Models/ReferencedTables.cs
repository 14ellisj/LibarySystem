using System.Text.Json.Serialization;

namespace Profile_Service.Models
{
    public class Address
    {
        public int id { get; set; }
        public int house_number { get; set; }
        public string street_name { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string postcode { get; set; }
    }

    public enum Role
    {
        ADMIN=1,
        MEMBER=2,
        GUEST=3,
        OPERATOR=4
    }

    public class Library
    {
        public int id { get; set; }
        [JsonPropertyName("library_address")]
        public Address Address { get; set; }
    }
}