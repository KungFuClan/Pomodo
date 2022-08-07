import * as queryString from 'query-string';

import SpotifyData from '../Data/SpotifyData';
import SpotifyService from '../ApiServices/SpotifyService';
import { useEffect } from 'react';
import { useState } from 'react';

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

        SpotifyData.updateTokenData(tokenResponse);
        window.location.href = "/";
    }, [tokenResponse]);

    return (
        <h1>
            Getting access token...
            {JSON.stringify(tokenResponse)}
        </h1>
        
    )

}