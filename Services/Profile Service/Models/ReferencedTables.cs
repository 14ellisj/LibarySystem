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

    public class Role
    {
        public int id { get; set; }
        public string role { get; set; }
    }

    public class Library
    {
        public int id { get; set; }
        [JsonPropertyName("library_address")]
        public Address Address { get; set; }
    }
}