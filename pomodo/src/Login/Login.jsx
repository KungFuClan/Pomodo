import { useState } from "react";
import { useEffect } from "react"
import SpotifyService from "../ApiServices/SpotifyService";
import { Redirect } from 'react-router-dom';

export function Login (props) {

    useEffect(() => {
        window.location.href = SpotifyService.getAuthorizationURL();
    }, []);

    return (
        <>
            <h1> Logging in... </h1>
            <h1> If you aren't redirected in a few seconds <a href={SpotifyService.getAuthorizationURL()}>click here</a> to be redirected.</h1>
        </>
    );

}