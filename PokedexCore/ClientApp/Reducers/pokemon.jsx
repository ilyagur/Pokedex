import * as Constants from './../Constants/All'

var initialState = {
    pokemons: [],
    typeFilters: ['rock', 'ground', 'fire', 'poison', 'grass', 'water', 'flying', 'bug', 'normal', 'fairy', 'electric', 'fighting', 'psychic', 'ice', 'ghost', 'dark', 'steel', 'dragon'],
    selectedTypeFilter: null,
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.RECEIVE_POKEMONS: return Object.assign({}, state, { pokemons: action.payload });
        case Constants.CHANGE_POKEMON_TYPE_FILTER: return Object.assign({}, state, { selectedTypeFilter: action.payload });
        default: return state;
    }
}