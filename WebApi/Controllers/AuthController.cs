using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AuthController(IConfiguration configuration, IUserAuthentication userAuthenticationService) : ControllerBase
    {
        private readonly IConfiguration _config = configuration;
        private readonly IUserAuthentication _userAuthenticationService = userAuthenticationService;

        [HttpGet("Login")]
        public IActionResult Login(string id, string email)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Invalid input parameters");
            }

            if (_userAuthenticationService.VerifyEmployeeCredentials(id, email))
            {
                var token = GenerateToken(id, email);
                return Ok(token);
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }


        private string GenerateToken(string userId, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:sub"]!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", userId),
                new Claim("Email", email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:iss"],
                audience: _config["Jwt:aud"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}