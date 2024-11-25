using Media_Service.Database;
using System.Text.Json.Serialization;

namespace Media_Service.Models
{

    public class Author : IFilterable
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

        public bool Filter(string query)
        {
            if (string.IsNullOrEmpty(query))
                return true;


            var authorSplit = query.Trim().ToLower().Split(" ");

            var first = authorSplit.First();
            var last = authorSplit.Last();

            if (authorSplit.Length == 1)
            {
                return FirstName.ToLower().Contains(first) || LastName.ToLower().Contains(last);
            }
            else
            {
                return
                    FirstName.ToLower().Contains(first)
                    || FirstName.ToLower().Contains(last)
                    || LastName.ToLower().Contains(first)
                    || LastName.ToLower().Contains(last);
            }
        }
    }
}
