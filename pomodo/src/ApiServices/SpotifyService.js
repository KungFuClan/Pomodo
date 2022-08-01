import * as querystring from 'query-string';

export default class SpotifyService {

    static AUTHORIZE_URL = "https://accounts.spotify.com/authorize?"
    static TOKEN_URL = "https://localhost:5001/api/SpotifyAuth/token";

    static CLIENT_ID = "898eba6f30b445cd8aa37a388f1b2318";
    static REDIRECT_URI = 'https://localhost:3000/spotify-auth-callback';

    static scopes = `user-read-private user-read-email user-modify-playback-state user-read-playback-position user-library-read streaming user-read-playback-state user-read-recently-played playlist-read-private`; 

    static getAuthorizationURL() {

        return this.AUTHORIZE_URL + querystring.stringify({
            response_type: 'code',
            client_id: this.CLIENT_ID,
            scope: this.scopes,
            redirect_uri: encodeURI(this.REDIRECT_URI)
        });
    }

    static async getAccessToken(code) {

        const response = await fetch(this.TOKEN_URL + `?code=${code}`, {
            method: "GET"
        })

        return response.json();

    }
        
}