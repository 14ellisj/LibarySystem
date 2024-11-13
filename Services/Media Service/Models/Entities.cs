using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Media_Service.Models
{
    [Table("Media")]    
    
    public class MediaEntity
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("genre_id")]
        public GenreEntity genre { get; set; }
        [ForeignKey("type_id")]
        public TypeEntity type { get; set; }
        [ForeignKey("author_id")]
        public AuthorEntity author { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float length { get; set; }
        public float rating { get; set; }

    }

    [Table("Author")]
    public class AuthorEntity
    {
        [Key]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    [Table("Type")]
    public class TypeEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }

    [Table("Genre")]
    public class GenreEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
