import { createStore, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'

import rootReducer from './../Reducers/rootReducer'

export default function configureStore() {
    var store = createStore(rootReducer, undefined, applyMiddleware(thunk));
    return store;
}