import 'bulma';

import { NowPlaying } from "../NowPlaying/NowPlaying";
import React from "react";
import SpotifyData from '../Data/SpotifyData';
import SpotifyService from '../ApiServices/SpotifyService';
import { SpotifyWebPlayback } from "../SpotifyWebSDK/SpotifyWebPlayback";

export function Home(props) {

        async function getRefreshToken() {
            const data = await SpotifyService.getRefreshedAccessToken(SpotifyData.getRefreshToken());
            SpotifyData.updateTokenData(data);
        }

    return (
        <>
            <div className="section">
                <h1 className="title is-1">Welcome to the home page!</h1>
            </div>
            
            <div className="section">
                <NowPlaying />
            </div>

            <div className="section">
                <br></br>
                <button onClick={getRefreshToken}>Refresh my token</button>
                <br></br>
                <strong>Access_Token</strong>: { SpotifyData.getAccessToken()}
                <br></br>
                <strong>Expire Time:</strong> { new Date(parseInt(SpotifyData.getTokenExpiration())).toString() }
                <br></br>
                <strong>Refresh_Token</strong>: { SpotifyData.getRefreshToken()}
            </div>
           
           <div className="section">
                <SpotifyWebPlayback />
           </div>
        </>
    )
} 