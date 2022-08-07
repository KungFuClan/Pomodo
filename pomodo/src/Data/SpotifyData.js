
const spotifyAccessTokenKey = "spotify-access-token";
const spotifyRefreshTokenKey = "spotify-refresh-token";
const spotifyTokenExpirationKey = "spotify-token-expiration";

export default class SpotifyData {

    static updateTokenData( {access_token, expires_in, refresh_token}) {
        this.setAccessToken(access_token);
        this.setTokenExpiration(expires_in);
        this.setRefreshToken(refresh_token);
    }

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

    static setTokenExpiration(expiresIn) {
        const expirationTime = Date.now() + expiresIn * 1000;
        localStorage.setItem(spotifyTokenExpirationKey, expirationTime);
    }
    
    static getTokenExpiration() {
        return localStorage.getItem(spotifyTokenExpirationKey);
    }
}
