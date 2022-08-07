import { useEffect, useState } from "react";
import SpotifyData from "../Data/SpotifyData";

export function SpotifyWebPlayback () {

    const [player, setPlayer] = useState();

    useEffect(() => {
        window.onSpotifyWebPlaybackSDKReady = () => {
    
            const script = document.createElement("script");
            script.src = "https://sdk.scdn.co/spotify-player.js";
            script.async = true;
        
            document.body.appendChild(script);

            const player = new window.Spotify.Player({
                name: 'Web Playback SDK',
                getOAuthToken: cb => { cb(SpotifyData.getAccessToken()); },
                volume: 0.5
            });
    
            setPlayer(player);
    
            player.addListener('ready', ({ device_id }) => {
                console.log('Ready with Device ID', device_id);
            });
    
            player.addListener('not_ready', ({ device_id }) => {
                console.log('Device ID has gone offline', device_id);
            });
    
            player.addListener('initialization_error', ({ message }) => { 
                console.error(message);
            });
          
            player.addListener('authentication_error', ({ message }) => {
                console.error(message);
            });
          
            player.addListener('account_error', ({ message }) => {
                console.error(message);
            });
    
            player.connect();
    
        };
    }, []);

    return (
        <>
        </>
    )
}