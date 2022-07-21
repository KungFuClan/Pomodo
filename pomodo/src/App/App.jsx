import 'bulma';

import {
    BrowserRouter,
    Route,
    Routes,
} from 'react-router-dom';

import { Home } from '../Home/Home';
import { Navbar } from '../Navbar/Navbar';
import React from 'react';

function App(props) {

    return (
        <div className='container'>
            <Navbar />

            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />} />
                </Routes>
        </BrowserRouter>
        </div>
    );
}

export default App;