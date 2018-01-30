import * as Constants from './../Constants/userConstants'

export function showLogInDialog() {
    return (dispatch) => {
        dispatch({
            type: Constants.LOGIN_DIALOG_VISIBLE,
            payload: true
        });
    }
}

export function hideLogInDialog() {
    return (dispatch) => {
        dispatch({
            type: Constants.LOGIN_DIALOG_VISIBLE,
            payload: false
        });
    }
}

export function showRegistrationDialog() {
    return (dispatch) => {
        dispatch({
            type: Constants.REGISTRATION_DIALOG_VISIBLE,
            payload: true
        });
    }
}

export function hideRegistrationDialog() {
    return (dispatch) => {
        dispatch({
            type: Constants.REGISTRATION_DIALOG_VISIBLE,
            payload: false
        });
    }
}

export function logIn(email, password) {
    return (dispatch) => {

        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        fetch(
            `http://localhost:46160/api/auth/login`,
            {
                method: 'POST',
                headers: headers,
                body: JSON.stringify( {
                    UserName: email,
                    Password: password,
                } )
            }
        )
            .catch(function (error) { console.log(error); });
    }
}