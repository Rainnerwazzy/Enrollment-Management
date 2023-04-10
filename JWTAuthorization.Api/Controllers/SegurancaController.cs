using JWTAuthorization.Api.Business.AuthService.Interfaces;
using JWTAuthorization.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthorization.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SegurancaController : ControllerBase
    {
        private readonly IAuthService _authService;

        public SegurancaController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("token")]
        public async Task<ActionResult> Login([FromBody] User login)
        {
            string tokenString = await _authService.Login(login);

            if (!string.IsNullOrEmpty(tokenString))
            {
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
       
    }
}
