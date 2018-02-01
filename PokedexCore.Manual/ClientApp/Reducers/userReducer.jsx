import * as Constants from './../Constants/userConstants'

const initialState = {
    isLoginDialogVisible: false,
    isRegistrationDialogVisible: false,
    fetchStatus: '',
    responseMessage: '',
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.LOGIN_DIALOG_VISIBLE: return Object.assign({}, state, { isLoginDialogVisible: action.payload });
        case Constants.REGISTRATION_DIALOG_VISIBLE: return Object.assign({}, state, { isRegistrationDialogVisible: action.payload });
        case Constants.SET_FETCH_STATUS: return Object.assign({}, state, { fetchStatus: action.payload });
        case Constants.SET_RESPONSE_MESSAGE: return Object.assign({}, state, { responseMessage: action.payload });
        default: return state;
    }
}