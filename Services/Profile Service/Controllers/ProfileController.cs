using AutoMapper;
using Profile_Service.Database;
using Profile_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography.Xml;



namespace Profile_Service.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProfileController(ILogger<ProfileController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProfile")]
        public async Task<JsonResult> Get(string? email, string? password)
        {
            var query = _context.Profile
                .Include(x => x.address)
                .Include(x => x.role)
                .Include(x => x.library)
                .AsQueryable();

                query = query.Where(x => x.email.ToLower() == (email.ToLower()));

            try {
                var results = await query.ToListAsync();
                var output = _mapper.Map<IEnumerable<ProfileEntity>, IEnumerable<UserProfile>>(results);
                return Json(output);
            }
            catch (Exception ex) {

                return Json("");
            }
        }

    [HttpPost(Name = "CreateProfile")]
    public async Task<IActionResult> Post([FromBody] RegisterDetails body)
    {
    var sql = "INSERT INTO Profile (email, first_name, last_name, password, role_id, library_id, address_id) " + "VALUES (@email, @firstName, @lastName, @password, @roleId, @libraryId, @addressId)";


    var email = (string)body.email;
    var firstName = (string)body.firstName;
    var lastName = (string)body.lastName;
    var password = (string)body.password;
    Random randomId = new Random();
    int roleID = randomId.Next(1, 5);
    int libraryID = randomId.Next(1, 5);
    int addressID = randomId.Next(1, 5);

            try
    {
        using var connection = new SqliteConnection(@"Data Source=../../database/Library Database.db");
        
        connection.Open();

        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@firstName", firstName);
        command.Parameters.AddWithValue("@lastName", lastName);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@roleId", roleID);
        command.Parameters.AddWithValue("@libraryId", libraryID);
        command.Parameters.AddWithValue("@addressId", addressID);
        
        
        var rowInserted = command.ExecuteNonQuery();

    
    return Ok();

    }
    catch (SqliteException ex)
    {
        Console.WriteLine(ex.Message);
        return Conflict("Error");
    }
            
            }
        }
}