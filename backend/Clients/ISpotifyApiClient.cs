namespace backend.Clients
{
    public interface ISpotifyApiClient
    {
        public Task<HttpResponseMessage> GetToken(string code);
    }
}