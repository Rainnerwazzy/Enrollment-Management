using JWTAuthorization.Api.Business.AuthService.Interfaces;
using JWTAuthorization.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthorization.Api.Business.AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Task<string> Login(User login)
        {
            bool validaUsu = ValidaUsuario(login);
            string stringToken = string.Empty;

            if (validaUsu)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expiry = DateTime.Now.AddMinutes(120);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: expiry, signingCredentials: credentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                stringToken = tokenHandler.WriteToken(token);
            }

            return Task.FromResult(stringToken);
        }

        private bool ValidaUsuario(User login)
        {
            if (login.Name == "universidade" && login.Password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
