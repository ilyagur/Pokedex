import * as Constants from './../Constants/Page'

export function changePokemonTypeFilter(filter) {
    return (dispatch) => {
        dispatch({
            type: Constants.CHANGE_POKEMON_TYPE_FILTER,
            payload: filter
        });
    }
}

export function searchPokemonByName(name) {
    return (dispatch) => {
        dispatch({
            type: Constants.SEARCH_POKEMON_BY_NAME,
            payload: name
        });
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

function receivePokemons(json) {
    return {
        type: Constants.RECEIVE_POKEMONS,
        payload: {
            pokemons: json
        }
    };
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
        );
}
