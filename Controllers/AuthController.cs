using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // In a real app, validate and save to your database
        if (string.IsNullOrWhiteSpace(model.Username) || 
            string.IsNullOrWhiteSpace(model.Email) || 
            string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest("Username, email, and password are required");
        }

        try
        {
            // Here you would typically:
            // 1. Check if user already exists
            // 2. Hash the password
            // 3. Save to database
            
            // For now, just generate a token
            var token = GenerateJwtToken(model.Email);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel userLogin)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // In a real app, validate against your database
        if (string.IsNullOrWhiteSpace(userLogin.Email) || string.IsNullOrWhiteSpace(userLogin.Password))
        {
            return BadRequest("Email and password are required");
        }

        try
        {
            var token = GenerateJwtToken(userLogin.Email);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private string GenerateJwtToken(string email)
    {
        var jwtKey = _config["Jwt:Key"];
        if (string.IsNullOrWhiteSpace(jwtKey))
        {
            throw new ArgumentNullException("JWT Key is not configured");
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Issuer"],
            claims: new[] { new Claim(ClaimTypes.Email, email) },
            expires: DateTime.UtcNow.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class RegisterModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}