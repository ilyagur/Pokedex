import * as Constants from './../Constants/Page'

export default function reducer(state = [], action) {
    switch (action.type) {
        case Constants.RECEIVE_POKEMONS: return action.payload.pokemons;
            default: return state;
    }
}