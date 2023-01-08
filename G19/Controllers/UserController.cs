using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public UserController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

    [HttpPost]
    [Route("SignUp")]
    public ActionResult SignUp(User user)
    {
        var exists = _G19Context.Users.Any(u=>u.Email==user.Email);
        if(exists)
        {
            return BadRequest();
        }
        var password = BCryptNet.HashPassword(user.Password);
        user.Password = password;
        _G19Context.Users.Add(user);
        _G19Context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login(User user)
    {
 
        var exists = _G19Context.Users.Any(u=>u.Email==user.Email);
        if(!exists)
        {
            return BadRequest();
        }
        var dbuser = _G19Context.Users.Single(u=>u.Email==user.Email);
        var password = BCryptNet.Verify(user.Password,dbuser.Password);
        if(!password)
        {
            return Unauthorized();
        }
        var userModel = new UserModel(dbuser.Email);
        var token = GenerateToken(userModel);

        return Ok(token);
    }
     private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
}
