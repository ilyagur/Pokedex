import * as Constants from './../Constants/All'

import { changePageNumber } from './Page'

export function changePokemonTypeFilter(filter) {
    return (dispatch, getState) => {

        dispatch({
            type: Constants.FILTER_SPINNER_VISIBLE,
            payload: true
        });

        dispatch({
            type: Constants.CHANGE_POKEMON_TYPE_FILTER,
            payload: filter
        });

        getPokemons(getState())
            .then(json => dispatch(receivePokemons(json)))
            .finally(f => {
                dispatch({
                    type: Constants.FILTER_SPINNER_VISIBLE,
                    payload: false
                });
            });
    }
}

function getPokemons(state) {
    let { currentPageNumber, pokemonsPerPage, selectedTypeFilter } = state.page;

    let limit = pokemonsPerPage,
        offset = (currentPageNumber - 1) * pokemonsPerPage,
        filter = selectedTypeFilter || 'ALL';

    return fetch(`https://localhost:44365/api/Pokemons/${limit}/${offset}/${filter}`)
        .then(
        response => response.json(),
        error => console.log(error)
        )
}

function receivePokemons(json) {
    return {
        type: Constants.RECEIVE_POKEMONS,
        payload: json
    };
}