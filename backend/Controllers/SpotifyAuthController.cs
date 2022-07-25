using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> Get([FromQuery] string code)
        {
            if(code == null)
                throw new ArgumentNullException("code");

            HttpResponseMessage response = await _spotifyApiClient.GetToken(code);

            return await response.Content.ReadAsStringAsync();
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
