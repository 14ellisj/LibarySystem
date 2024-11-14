using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profile_Service.Models
{
    [Table("Profile")]    
    
    public class UserEntity
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("role_id")]
        public RoleEntity role { get; set; }
        [ForeignKey("library_id")]
        public LibraryEntity library { get; set; }
        [ForeignKey("address_id")]
        public AddressEntity address { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string DOB { get; set; }
        public string password { get; set; }
    }
    
    [Table("Role")]
    public class RoleEntity
    {
        [Key]
        public int id { get; set; }
        public string role { get; set; }
    }

    [Table("Library")]
    public class LibraryEntity
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("address_id")]
        public AddressEntity address { get; set; }
    }

    [Table("Address")]
    public class AddressEntity
    {
        [Key]
        public int id { get; set; }
        public int houseNumber { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string postcode { get; set; }
    }
}
