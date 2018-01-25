import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Header extends Component {
    render() {
        return (
            <div>
                <nav className="navbar navbar-inverse navbar-fixed-top">
                    <div className="container">
                        <div className="navbar-header">
                            <a href="/Home/Index" className="navbar-brand">React Pokedex</a>
                        </div>
                        <div className="navbar-collapse collapse">
                            <ul className="nav navbar-nav navbar-right">
                                <li><a href="/Account/Register">Register</a></li>
                                <li><a href="Account/Login">Log in</a></li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        )
    }
}

export default Header