import { combineReducers } from 'redux'

import userReducer from './userReducer'
//import pageReducer from './page'
//import userReducer from './user'


export default combineReducers({
    //https://redux.js.org/docs/basics/Reducers.html
    userContext: userReducer,
    //page: pageReducer,
    //user: userReducer,
})