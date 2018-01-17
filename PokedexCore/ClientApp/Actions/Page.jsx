import * as Constants from './../Constants/All'

export function searchPokemonByName(name) {
    return (dispatch, getState) => {

        dispatch({
            type: Constants.CHANGE_PAGE_NUMBER,
            payload: 1
        });

        dispatch({
            type: Constants.SEARCH_SPINNER_VISIBLE,
            payload: true
        });

        if (!name) {
            getPokemons(getState()).then(json => dispatch(receivePokemons(json)));

            dispatch({
                type: Constants.SEARCH_SPINNER_VISIBLE,
                payload: false
            });

            return;
        }

        fetch(`https://localhost:44365/api/Pokemon/${name}/`)
            .then(
            response => response.json(),
            error => console.log(error)
            )
            .then(json => {
                debugger;
                dispatch(receivePokemons([json]));
            })
            .finally(f =>
                dispatch({
                    type: Constants.SEARCH_SPINNER_VISIBLE,
                    payload: false
                }));
    }
}

export function addPokemonToFavoriteById(id) {
    return (dispatch) => {
        dispatch({
            type: Constants.ADD_POKEMON_TO_FAVORITE_BY_ID,
            payload: id
        });
    }
}

export function changePageNumber(pageNumber) {
    return (dispatch, getState) => {
        dispatch({
            type: Constants.CHANGE_PAGE_NUMBER,
            payload: pageNumber
        });

        getPokemons(getState()).then(json => dispatch(receivePokemons(json)));
    }
}

export function changeItemsAmountPerPage(amout) {
    return (dispatch, getState) => {
        dispatch({
            type: Constants.CHANGE_PAGE_NUMBER,
            payload: 1
        });

        dispatch({
            type: Constants.CHANGE_ITEMS_AMOUNT_PER_PAGE,
            payload: amout
        });

        getPokemons(getState()).then(json => dispatch(receivePokemons(json)));
    }
}

export function suggestPokemons() {
    return (dispatch, getState) => {

        dispatch({
            type: Constants.SUGGEST_SPINNER_VISIBLE,
            payload: true
        });

        dispatch({
            type: Constants.CHANGE_PAGE_NUMBER,
            payload: 1
        });

        let { pokemonsPerPage } = getState().page;

        fetch(`https://localhost:44365/api/SuggestPokemons/${pokemonsPerPage}/`)
            .then(
            response => response.json(),
            error => console.log(error)
            )
            .then(json => {
                dispatch(receivePokemons(json));
            })
            .finally(f =>
                dispatch({
                    type: Constants.SUGGEST_SPINNER_VISIBLE,
                    payload: false
                }));
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

