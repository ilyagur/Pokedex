import { createStore } from 'redux'

import rootReducer from './../Reducers/index'

export default function configureStore(initialState) {
    return createStore(rootReducer, initialState);
}