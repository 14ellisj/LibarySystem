﻿using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class Library
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public AddressEntity address { get; : set; }
        public string name { get; : set; }
    }
}
