using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using backend.Clients;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyAuthController : ControllerBase
    {

        private readonly ISpotifyApiClient _spotifyApiClient;

        public SpotifyAuthController(ISpotifyApiClient spotifyApiClient)
        {
            _spotifyApiClient = spotifyApiClient; 
        }


        // GET: api/<SpotifyAuthController>/token
        [HttpGet]
        [Route("token")]
        public async Task<IActionResult> Get([FromQuery] string code)
        {
            if(code == null)
                throw new ArgumentNullException(nameof(code));

            HttpResponseMessage response = await _spotifyApiClient.GetToken(code);
            return Ok(await response.Content.ReadAsStringAsync());
            
        }

        [HttpGet]
        [Route("now-playing")]
        public async Task<IActionResult> Get()
        {
            AuthenticationHeaderValue.TryParse(Request.Headers["Authentication"], out AuthenticationHeaderValue? authHeader);
            string token = authHeader?.Parameter ?? "";

            if(token is null)
            {
                return new UnauthorizedObjectResult(new { message = "Token is null" });
            }

            HttpResponseMessage response = await _spotifyApiClient.GetNowPlaying(token);

            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
