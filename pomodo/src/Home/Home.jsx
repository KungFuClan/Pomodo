import React from "react";
import 'bulma';
import { NowPlaying } from "../NowPlaying/NowPlaying";
import { SpotifyWebPlayback } from "../SpotifyWebSDK/SpotifyWebPlayback";

export function Home(props) {

    return (
        <>
            <div className="section">
                <h1 className="title is-1">Welcome to the home page!</h1>
            </div>
            
            <div className="section">
                <NowPlaying />
            </div>
           
           <div className="section">
                <SpotifyWebPlayback />
           </div>
        </>
    )
} 