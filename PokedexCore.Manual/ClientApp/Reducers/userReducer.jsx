import * as Constants from './../Constants/userConstants'

const initialState = {
    isLoginDialogVisible: false,
    isRegistrationDialogVisible: false
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.LOGIN_DIALOG_VISIBLE: return Object.assign({}, state, { isLoginDialogVisible: action.payload });
        case Constants.REGISTRATION_DIALOG_VISIBLE: return Object.assign({}, state, { isRegistrationDialogVisible: action.payload });
        default: return state;
    }
}