using Media_Service.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Media_Service.Models
{

    [Table("MediaItem")]
    public class MediaItemEntity
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("media_id")]
        public MediaEntity media { get ; set; }

        [ForeignKey("borrower_id")]
        public UserEntity? borrower { get; set; }
        public int? borrower_id;

        [ForeignKey("library_id")]
        public LibraryEntity library { get; set; }
        public int library_id {get; set;}
    }

    [Table("Profile")]
    public class UserEntity
    {
        [Key]
        public int id { get; set; }
    }

    [Table("Library")]
    public class LibraryEntity
    {
        [Key]
        public int id { get; set; }
        public AddressEntity address { get; : set; }

    }

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
        public ICollection<MediaItemEntity> media_items { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string length { get; set; }
        public string rating { get; set; }
        public string image { get; set; } 
    }

    [Table("Author")]
    public class AuthorEntity
    {
        [Key]
        public int id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
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

    [Table("Address")]
    public class AddressEntity
    {
        [Key]
        public int id { get; set; }
        public int house_number { get; set;}
        public string street_name { get; set;}
        public string city { get; set;}
        public string county { get; set;}
        public string postcode { get; set;}
    }
}
