import SpotifyData from "../Data/SpotifyData";
import SpotifyService from "../ApiServices/SpotifyService";
import { useEffect } from "react";
import { useState } from "react";

export function NowPlaying ({ nowPlayingData }) {
    
    const [playing, setPlaying] = useState();
    const [albumImageUrl, setAlbumImageUrl] = useState();
    const [artistNames, setArtistNames] = useState(); 
    const [songTitle, setSongTitle] = useState();

    useEffect(() => {
        ( async () => { 
            
            const nowPlaying = await SpotifyService.getNowPlaying();

            setPlaying(nowPlaying);
            setAlbumImageUrl(nowPlaying.item.album.images[1].url);
            setSongTitle(nowPlaying.item.name);
            setArtistNames(nowPlaying.item.artists.map( artist => artist.name).join(','));
        })();
    }, [])

    return ( playing &&
        <div className="level">
            <div className="level-item has-text-centered">
                <img src={albumImageUrl} />
            </div>
            <div className="level-item has-text-centered">
                <div>
                    <h2 className="title is-2">{songTitle}</h2>
                    <br/>
                    <h2 className="subtitle is-4">{artistNames}</h2>
                </div>
            </div>
        </div>
    )
}