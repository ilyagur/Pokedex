import React, { Component } from 'react'

import LogIn from './../Components/logInComponent'
import Registration from './../Components/registrationComponent'

class Header extends Component {
    render() {

        const {
            userContext: {
                isLoginDialogVisible,
                isRegistrationDialogVisible,
                fetchStatus,
                responseMessage,
            },
            userActions: {
                showLogInDialog,
                hideLogInDialog,
                showRegistrationDialog,
                hideRegistrationDialog,
                registrate,
                logIn,
            },
        } = this.props;

        return (
            <div className="container-fluid">
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
                    <a className="navbar-brand" href="#">Pokedex</a>

                    <div className="collapse navbar-collapse" id="navbarColor02">
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item active">
                                <a className="nav-link" href="#">Home <span className="sr-only">(current)</span></a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Favorite Pokemons</a>
                            </li>
                        </ul>
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <a onClick={showLogInDialog} className="nav-link" href="#">Log In</a>
                            </li>
                            <li className="nav-item">
                                <a onClick={showRegistrationDialog} className="nav-link" href="#">Registration</a>
                            </li>
                        </ul>
                    </div>
                </nav>
                <LogIn
                    hideLogInDialog={hideLogInDialog}
                    isLoginDialogVisible={isLoginDialogVisible}
                    logIn={logIn}
                    fetchStatus={fetchStatus}
                    responseMessage={responseMessage} />
                <Registration
                    hideRegistrationDialog={hideRegistrationDialog}
                    isRegistrationDialogVisible={isRegistrationDialogVisible}
                    registrate={registrate}
                    fetchStatus={fetchStatus}
                    responseMessage={responseMessage} />
            </div>
            )
    }
}

export default Header