import 'bulma';

import {
    BrowserRouter,
    Route,
    Routes,
} from 'react-router-dom';

import { Home } from '../Home/Home';
import { Navbar } from '../Navbar/Navbar';
import React from 'react';
import { Login } from '../Login/Login';
import { SpotifyAuthCallback } from '../SpotifyAuthCallback/SpotifyAuthCallback';

function App(props) {

    return (
        <div className='container'>
            <Navbar />

            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />}/>
                    <Route path="/spotify-auth-callback" element={<SpotifyAuthCallback />} />
                </Routes>
        </BrowserRouter>
        </div>
    );
}

export default App;