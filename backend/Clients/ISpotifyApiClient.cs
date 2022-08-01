namespace backend.Clients
{
    public interface ISpotifyApiClient
    {
        public Task<HttpResponseMessage> GetToken(string code);

        public Task<HttpResponseMessage> GetNowPlaying(string token);

        public Task<HttpResponseMessage> RefreshToken(string refreshToken);
    }
}