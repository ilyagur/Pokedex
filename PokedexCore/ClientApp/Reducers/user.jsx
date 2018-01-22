import * as Constants from './../Constants/All'

var initialState = {
    isLoggedIn: false,
    userName: 'John Doe',
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.RECEIVE_USER: return Object.assign({}, state, action.payload );
        default: return state;
    }
}