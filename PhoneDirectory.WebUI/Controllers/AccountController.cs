using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PhoneDirectory.Domain.Abstract;
using PhoneDirectory.Domain.Entity;
using System.Security.Claims;
using PhoneDirectory.WebUI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace PhoneDirectory.WebUI.Controllers
{
    /// <summary>
    /// Пример аутентификации на основе JWT токена. Пароль хранится в открытом виде в БД, параметры токена в коде.
    /// </summary>
    [ApiController]    
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public AuthController(IEmployeeRepository employeeRepo)
        {
            employeeRepository = employeeRepo;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Login model)
        {
            var employee = employeeRepository.Get(model.Email, model.Password);

            if (employee != null)
            {
                var token = GenerateJWT(employee);

                return Ok(new { access_token = token });
            }

            return Unauthorized();
        }

        private string GenerateJWT(Employee emp)
        {
            string Issuer = "authServer";
            string Audience = "resourceServer";
            string Secret = "secretsecretsecretsecret";
            int TokenLifetime = 3000;

            var securutyKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, emp.Email),
                new Claim(JwtRegisteredClaimNames.Sub, emp.Id.ToString())
            };

            var token = new JwtSecurityToken(
                Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddSeconds(TokenLifetime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
