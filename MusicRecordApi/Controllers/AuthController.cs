using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            Roles role;

            if (login.Username == "admin" && login.Password == "admin")
            {
                role = Roles.Admin;
            }
            else if (login.Username == "user" && login.Password == "user")
            {
                role = Roles.User;
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }     

            var token = GenerateJwtToken(login.Username, role);
            return Ok(new { token, role = role.ToString() });
        }

        private string GenerateJwtToken(string username, Roles role)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Claims are the pieces of information "baked" into the token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role.ToString()) // You can add roles here

            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public enum Roles
    {
        Admin,
        User
    }
}
