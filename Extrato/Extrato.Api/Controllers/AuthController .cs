using Extrato.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly JwtSettings _jwtSettings;
    private readonly Login _login;

    public AuthController(IOptions<JwtSettings> jwtSettings, IOptions<Login> login)
    {
        _jwtSettings = jwtSettings.Value;
        _login = login.Value;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Login model)
    {
        
        if (model.Username == _login.Username && model.Password == _login.Password) 
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }
}

