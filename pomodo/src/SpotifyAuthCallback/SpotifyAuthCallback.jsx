import * as queryString from 'query-string';
import { useState } from 'react';
import { useEffect } from 'react';
import SpotifyService from '../ApiServices/SpotifyService';

export function SpotifyAuthCallback (props) {

    const [queryParams, setQueryParams] = useState({});
    const [accessToken, setAccessToken] = useState();

    useEffect(() => {

        setQueryParams( queryString.parse(window.location.search));

    }, []);

    useEffect(() => {

        if(queryParams.code === undefined) {
            return;
        }

        async function GetAccessToken () {
            const token = await SpotifyService.getAccessToken(queryParams.code);

            setAccessToken(token);
        }

        GetAccessToken();

    }, [queryParams])

    return (
        <h1>
            Getting access token...
            {JSON.stringify(accessToken)}
        </h1>
        
    )

}