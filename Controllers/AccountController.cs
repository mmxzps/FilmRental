using FilmRental.Data;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly FilmRentalContext _context;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService accountService, IUserService userService, FilmRentalContext context, IConfiguration configuration)
        {
            _accountService = accountService;
            _userService = userService;
            _context = context;
            _configuration = configuration;
        }



        [HttpPost("Register")]
        public IActionResult Register(RegisterUserDTO registerUserDTO)
        {
            var existingUser = _context.Users.SingleOrDefault(x => x.Email == registerUserDTO.Email);

            if (existingUser != null)
            {
                return BadRequest("Email is already in use!");
            }
            //hashing the pass. with help of BCrypt package.
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password);

            var newAcc = new Account
            {
                FirstName = registerUserDTO.FirstName,
                LastName = registerUserDTO.LastName,
                Email = registerUserDTO.Email,
                PasswordHash = passwordHash
            };

            _context.Accounts.Add(newAcc);
            _context.SaveChanges();
            return Ok();
        }




        [HttpPost("Login")]
        public IActionResult Login(LoginUserDTO loginUserDTO)
        {
            var existingUser = _context.Accounts.SingleOrDefault(x => x.Email == loginUserDTO.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, existingUser.PasswordHash))
            {
                return Unauthorized("Invalid Email or password!");
            }
            var token = GenerateJwtToken(existingUser);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{account.FirstName} {account.LastName}"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email, account.Email),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
