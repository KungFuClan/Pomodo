import * as queryString from 'query-string';
import { useState } from 'react';
import { useEffect } from 'react';
import SpotifyService from '../ApiServices/SpotifyService';
import SpotifyData from '../Data/SpotifyData';

export function SpotifyAuthCallback (props) {

    const [queryParams, setQueryParams] = useState({});
    const [tokenResponse, setTokenResponse] = useState();

    useEffect(() => {
        setQueryParams(queryString.parse(window.location.search));
    }, []);

    useEffect(() => {
        if(queryParams.code === undefined) {
            return;
        }

        (async () => {
            const token = await SpotifyService.getAccessToken(queryParams.code);
            setTokenResponse(token);
        })();

    }, [queryParams]);

    useEffect(() => {

        if(tokenResponse === undefined) {
            return;
        }

        SpotifyData.setAccessToken(tokenResponse.access_token)
        SpotifyData.setRefreshToken(tokenResponse.refresh_token);
        SpotifyData.setTokenExpiration(tokenResponse.expires_in)
        window.location.href = "/";
    }, [tokenResponse]);

    return (
        <h1>
            Getting access token...
            {JSON.stringify(tokenResponse)}
        </h1>
        
    )

}