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

        dispatch({
            type: Constants.SET_FETCH_STATUS,
            payload: 'PENDING'
        });

        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        fetch(
            'https://localhost:44378/api/auth/login',
            {
                method: 'POST',
                headers: headers,
                body: JSON.stringify({
                    UserName: email,
                    Password: password,
                })
            }
        )
            .then(response => {
                if (response.ok) {
                    dispatch({
                        type: Constants.SET_FETCH_STATUS,
                        payload: 'SUCCESS'
                    });
                } else {
                    dispatch({
                        type: Constants.SET_FETCH_STATUS,
                        payload: 'FAIL'
                    });
                }

                return response.json();
            })
            .then(text => {

                console.log(text)

                dispatch({
                    type: Constants.SET_RESPONSE_MESSAGE,
                    payload: text
                });
            })
    }
}

export function registrate(registrationModel) {
    return (dispatch) => {

        dispatch({
            type: Constants.SET_FETCH_STATUS,
            payload: 'PENDING'
        });

        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        fetch(
            'https://localhost:44378/api/Account',
            {
                method: 'POST',
                headers: headers,
                body: JSON.stringify(registrationModel),
            }
        )
            .then(response => {
                if (response.ok) {
                    dispatch({
                        type: Constants.SET_FETCH_STATUS,
                        payload: 'SUCCESS'
                    });
                } else {
                    dispatch({
                        type: Constants.SET_FETCH_STATUS,
                        payload: 'FAIL'
                    });
                }

                return response.json();
            })
            .then(text => {

                console.log(text)

                dispatch({
                    type: Constants.SET_RESPONSE_MESSAGE,
                    payload: text
                });
            })
    }
}

export function setResponseMessage(message) {
    return (dispatch) => {
        dispatch({
            type: 'SET_RESPONSE_MESSAGE',
            payload: message
        });
    }
}

function handleErrors(response) {
    if (!response.ok) {
        console.log(response.statusText);
    }

    return response;
}