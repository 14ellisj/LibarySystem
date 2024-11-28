using System.Text.Json.Serialization;

namespace Media_Service.Models
{
    public class BorrowItemRequest
    {
        [JsonPropertyName("media_id")]
        public int? MediaId { get; set; }
        [JsonPropertyName("profile_id")]
        public int? ProfileId { get; set; }

    }
}
