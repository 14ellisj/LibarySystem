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
    public class ReserveItemRequest
    {
        [JsonPropertyName("media_id")]
        public int? MediaId { get; set; }
        [JsonPropertyName("profile_id")]
        public int? ProfileId { get; set; }

    }
    public class MoveItemRequest
    {
        [JsonPropertyName("media_id")]
        public int? MediaId { get; set; }
        [JsonPropertyName("library_id")]
        public int? LibraryId { get; set; }

    }
}
