using System.Web;
using System.Net.Http.Headers;
using backend.Settings;
using Microsoft.Extensions.Options;

namespace backend.Clients
{
    public class SpotifyApiClient : ISpotifyApiClient
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SpotifyClientSettings _spotifyClientSettings;
        private const string TOKEN_URL = $"https://accounts.spotify.com/api/token";
        private const string AUTHORIZE_URL = "https://accounts.spotify.com/authorize?";
        private const string PLAYLISTS_URL = "https://api.spotify.com/v1/me/playlists";
        private const string DEVICES_URL = "https://api.spotify.com/v1/me/player/devices";
        private const string PLAY_URL = "https://api.spotify.com/v1/me/player/play";
        private const string PAUSE_URL = "https://api.spotify.com/v1/me/player/pause";
        private const string NEXT_URL = "https://api.spotify.com/v1/me/player/next";
        private const string PREVIOUS_URL = "https://api.spotify.com/v1/me/player/previous";
        private const string PLAYER_URL = "https://api.spotify.com/v1/me/player";
        private const string TRACKS_URL = "https://api.spotify.com/v1/playlists/{{PlaylistId}}/tracks";
        private const string CURRENTLYPLAYING_URL = "https://api.spotify.com/v1/me/player/currently-playing";
        private const string SHUFFLE_URL = "https://api.spotify.com/v1/me/player/shuffle";

        public SpotifyApiClient(IHttpClientFactory httpClientFactory, IOptions<SpotifyClientSettings> spotifyClientSettings)
        {
            _httpClientFactory = httpClientFactory;
            _spotifyClientSettings = spotifyClientSettings.Value;
        }

        public async Task<HttpResponseMessage> GetToken(string code)
        {

            Dictionary<string, string> postParams = new Dictionary<string, string>
            {
                { "code", code },
                { "redirect_uri", _spotifyClientSettings.baseUrl + _spotifyClientSettings.redirectUri },
                { "client_id", _spotifyClientSettings.clientId},
                { "client_secret", _spotifyClientSettings.clientSecret },
                { "grant_type", "authorization_code" }
            };

            HttpClient httpClient = _httpClientFactory.CreateClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, TOKEN_URL);
            request.Content = new FormUrlEncodedContent(postParams);

            return await httpClient.SendAsync(request);

        }
    }
}
