using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZuydSpeelt.Models;

namespace ZuydSpeelt.Controllers
{

    public class LoginPayload
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public LoginPayload(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class ReturnPayload
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Email { get; set; }

        [JsonConstructor]
        public ReturnPayload(string token, DateTime expiresAt, string email)
        {
            Token = token;
            ExpiresAt = expiresAt;
            Email = email;
        }
    }

    [Route("")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ZuydSpeeltContext _context;

        public AuthController(ZuydSpeeltContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginPayload payload)
        {
            // check if a username and password were actually sent
            if (payload.Email == string.Empty || payload.Password == string.Empty)
            {
                return BadRequest(new { message = "Invalid login request" });
            }

            // check if the user exists in the database
            var user = _context.User.FirstOrDefault(u => u.Email == payload.Email && u.Password == payload.Password);

            // if the user exists, generate an access token for the user
            if (user != null)
            {
                return Ok(GenerateToken(user));
            }

            return Unauthorized(new { message = "User not found" });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var userid = _context.User.Max(u => u.Id) + 1;
                user.Id = userid;
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "User created successfully" });
            }

            return BadRequest(new { message = "Invalid model state" });
        }

        private ReturnPayload GenerateToken(User user)
        {
            var issuer = HttpContext.Request.Host.Value;
            var audience = HttpContext.Request.Path;
            var key = Encoding.ASCII.GetBytes(JWTKey.Instance.GetKey());
            var expiresAt = DateTime.Now.AddHours(24);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = expiresAt,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return new ReturnPayload(stringToken, expiresAt, user.Email);
        }

    }
}