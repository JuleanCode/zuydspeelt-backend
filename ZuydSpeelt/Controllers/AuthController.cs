using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ZuydSpeelt.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var issuer = "backendwebsite.com";
            var audience = "backendwebsite.com";
            var key = Encoding.ASCII.GetBytes("FFE1umUGUW1SaReshHGYlg==");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, "Ruben"),
                new Claim(JwtRegisteredClaimNames.Email, "claessensruben2812@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.Now.AddMinutes(5),
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
            return Ok(stringToken);
        }
    }
}