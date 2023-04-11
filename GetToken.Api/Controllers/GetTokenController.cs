using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetToken.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class GetTokenController : Controller
    {
        private readonly ILogger<GetTokenController> _logger;

        public GetTokenController(ILogger<GetTokenController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-token")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize]
        public async Task<ActionResult> GetAllRegistrations()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:4435");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "geek_universidade",
                ClientSecret = "my_super_secret",
                Scope = "geek_universidade"
            });

            var token = tokenResponse.AccessToken;

            if (!string.IsNullOrEmpty(token)) 
            {
                return Ok(token);
            }

            return NotFound("token not found");
        }
    }
}
