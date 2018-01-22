import { combineReducers } from 'redux'

import pokemonsReducer from './pokemon'
import pageReducer from './page'
import userReducer from './user'


export default combineReducers({
    //https://redux.js.org/docs/basics/Reducers.html
    pokemons: pokemonsReducer,
    page: pageReducer,
    user: userReducer,
})