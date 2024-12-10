using AutoMapper;
using Profile_Service.Database;
using Profile_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;



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
        public async Task<JsonResult> Get(string? email)
        {
            var query = _context.Profile
                .Include(x => x.address)
                .Include(x => x.role)
                .Include(x => x.library)
                .AsQueryable();

                query = query.Where(x => x.email.ToLower().Contains(email.ToLower()));

            var results = await query.ToListAsync();
            var output = _mapper.Map<IEnumerable<ProfileEntity>, IEnumerable<UserProfile>>(results);


            return Json(output);
        }

    [HttpPost(Name = "CreateProfile")]
    public async Task<IActionResult> Post([FromBody] RegisterDetails body)
    {

    var sql = "INSERT INTO Profile (email, first_name, last_name, password) " + "VALUES (@email, @firstName, @lastName, @password)";

    var email = (string)body.email;
    var firstName = (string)body.firstName;
    var lastName = (string)body.lastName;
    var password = (string)body.password;

    try
    {
        using var connection = new SqliteConnection(@"Data Source=C:\Users\jdent\OneDrive\Desktop\1) Uni stuff\Year 3\Software Architecture and Design\LibarySystem\LibarySystem\database\Library Database.db");
        connection.Open();

        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@firstName", firstName);
        command.Parameters.AddWithValue("@lastName", lastName);
        command.Parameters.AddWithValue("@password", password);
        
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