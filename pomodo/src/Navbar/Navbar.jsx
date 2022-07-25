import 'bulma';

import React from 'react';
import { toggleNavbarBurger } from './bulma.js';

export function Navbar(props) {
    return (
        <nav className="navbar" role="navigation" aria-label="main navigation">
            <div className="navbar-brand">
                <a className="navbar-item" href="/">
                    Pomogo
                    {/* img here */}
                </a>

                { /* hamburger menu button */}
                <button className="navbar-burger" aria-label="menu" aria-expanded="false" data-target="navbarExpand" onClick={toggleNavbarBurger}>
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                </button>
                </div>

                <div id="navbarExpand" className="navbar-menu">
                    <div className="navbar-start">
                    <a href="/" className="navbar-item">
                        Home
                    </a>
                </div>

                <div className="navbar-end">
                    <div className="navbar-item">
                        <div className="buttons">
                        <button className="button is-primary">
                            <strong>Sign up</strong>
                        </button>
                        <a href="/login" role="button" className="button is-light">
                            Log in
                        </a>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    )
}