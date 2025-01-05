using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;

        public EmailController(ILogger<EmailController> logger)
        {
            _logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                _logger.LogInformation("Starting email sending process.");

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("amlreservationsemail@gmail.com", "dnay bhdp mdih towj"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("jakeellis5000@gmail.com"),
                    Subject = emailRequest.Subject,
                    Body = emailRequest.Body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(emailRequest.To);

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation("Email sent successfully.");
                return Ok(new { Message = "Email sent successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending email");

                return StatusCode(500, new { Message = "Error sending email. Please try again later.", Details = ex.Message });
            }
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
