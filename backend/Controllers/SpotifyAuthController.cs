﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> Get([FromQuery] string code)
        {
            if(code == null)
                throw new ArgumentNullException("code");

            HttpResponseMessage response = await _spotifyApiClient.GetToken(code);

            return await response.Content.ReadAsStringAsync();
            
        }

        [HttpGet]
        [Route("now-playing")]
        public async Task<string> Get()
        {
            AuthenticationHeaderValue authHeader;
            AuthenticationHeaderValue.TryParse(Request.Headers["Authentication"], out authHeader);

            string token = authHeader.Parameter;

            HttpResponseMessage response = await _spotifyApiClient.GetNowPlaying(token);

            return await response.Content.ReadAsStringAsync();
        }
    }
}