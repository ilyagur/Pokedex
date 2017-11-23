import { combineReducers } from 'redux'

import pokemonsReducer from './pokemon'
import pageReducer from './page'

export default combineReducers({
    //https://redux.js.org/docs/basics/Reducers.html
    pokemons: pokemonsReducer,
    page: pageReducer
})