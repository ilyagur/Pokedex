import { combineReducers } from 'redux'

import pokemonsReducer from './pokemon'

export default combineReducers({
    //https://redux.js.org/docs/basics/Reducers.html
    pokemons: pokemonsReducer
})