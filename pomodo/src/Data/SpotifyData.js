
const spotifyAccessTokenKey = "spotify-access-token";
const spotifyRefreshTokenKey = "spotify-refresh-token";
const spotifyTokenExpirationKey = "spotify-token-expiration";

export default class SpotifyData {

    static setAccessToken(token) {
        localStorage.setItem(spotifyAccessTokenKey, token);
    }
    
    static getAccessToken() {
        return localStorage.getItem(spotifyAccessTokenKey);
    }
    
    static setRefreshToken(token) {
        localStorage.setItem(spotifyRefreshTokenKey, token);
    }
    
    static getRefreshToken() {
        return localStorage.getItem(spotifyRefreshTokenKey);
    }

    static setTokenExpiration(time) {
        localStorage.setItem(spotifyTokenExpirationKey, time);
    }
    
    static getTokenExpiration() {
        return localStorage.getItem(spotifyTokenExpirationKey);
    }
}
