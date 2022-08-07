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

        // URLs from https://developer.spotify.com/documentation/web-api/reference/#/
        private const string TOKEN_URL = $"https://accounts.spotify.com/api/token";
        private const string AUTHORIZE_URL = "https://accounts.spotify.com/authorize";
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

        private HttpClient CreateAuthenticatedClient(string token)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }

        private string CreateGetRequestQueryParams(Dictionary<string, string> getParams)
        {
            List<string> queryParams = new List<string>();

            foreach (KeyValuePair<string, string> param in getParams)
            {
                queryParams.Add(param.Key + "=" + param.Value);
            }

            return "?" + String.Join("&", queryParams.ToArray());
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

        public async Task<HttpResponseMessage> RefreshToken(string refreshToken)
        {
            Dictionary<string, string> postParams = new Dictionary<string, string>
            {
                { "refresh_token", refreshToken },
                { "client_id", _spotifyClientSettings.clientId},
                { "client_secret", _spotifyClientSettings.clientSecret },
                { "grant_type", "refresh_token" }
            };

            HttpClient httpClient = _httpClientFactory.CreateClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, TOKEN_URL);
            request.Content = new FormUrlEncodedContent(postParams);

            return await httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetNowPlaying(string token)
        {
            HttpClient httpClient = this.CreateAuthenticatedClient(token);

            Dictionary<string, string> getParams = new Dictionary<string, string>
            {
                {"additional_types", "track,episode" }
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, CURRENTLYPLAYING_URL + this.CreateGetRequestQueryParams(getParams));
            
            return await httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetAuthorizationCode(string scope)
        {
            Dictionary<string, string> getParams = new Dictionary<string, string>
            {
                { "response_type", "code" },
                { "client_id", _spotifyClientSettings.clientId },
                { "scope",  scope },
                { "redirect_uri", _spotifyClientSettings.redirectUri }
            };

            HttpClient httpClient = _httpClientFactory.CreateClient();

            List<string> queryParams = new List<string>();

            foreach (KeyValuePair<string, string> param in getParams)
            {
                queryParams.Add(param.Key + "=" + param.Value);
            }

            string getCodeUrl = AUTHORIZE_URL + "?" + String.Join("&", queryParams.ToArray());

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, getCodeUrl);

            return await httpClient.SendAsync(request);
        }
    }
}
