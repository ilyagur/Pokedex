import * as Constants from './../Constants/Page'

export function showSuggestSpinner() {
    return (dispatch) => {
        dispatch({
            type: Constants.SUGGEST_SPINNER_VISIBLE,
            payload: true
        });
    }
}

export function hideSuggestSpinner() {
    return (dispatch) => {
        dispatch({
            type: Constants.SUGGEST_SPINNER_VISIBLE,
            payload: false
        });
    }
}

export function changePokemonTypeFilter(filter) {
    return (dispatch) => {
        dispatch({
            type: Constants.CHANGE_POKEMON_TYPE_FILTER,
            payload: filter
        });
    }
}

export function searchPokemonByName(name) {
    return (dispatch, getState) => {

        let { pokemonsPerPage } = getState().page;

        fetch(`https://localhost:44365/api/SearchPokemonByName/${name}/`)
            .then(
            response => response.json(),
            error => console.log(error)
        )
            .then(json => dispatch(receivePokemons(json)));
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

        let { currentPageNumber, pokemonsPerPage, selectedTypeFilter } = getState().page;

        let limit = pokemonsPerPage,
            offset = (currentPageNumber - 1) * pokemonsPerPage,
            filter = selectedTypeFilter || 'ALL';

        fetch(`https://localhost:44365/api/Pokemons/${limit}/${offset}/${filter}`)
            .then(
            response => response.json(),
            error => console.log(error)
            )
            .then(json => dispatch(receivePokemons(json)));
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

        let { currentPageNumber, pokemonsPerPage, selectedTypeFilter } = getState().page;

        let limit = pokemonsPerPage,
            offset = (currentPageNumber - 1) * pokemonsPerPage,
            filter = selectedTypeFilter || 'ALL';

        fetch(`https://localhost:44365/api/Pokemons/${limit}/${offset}/${filter}`)
            .then(
            response => response.json(),
            error => console.log(error)
        )
            .then(json => dispatch(receivePokemons(json)));
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

                dispatch({
                    type: Constants.SUGGEST_SPINNER_VISIBLE,
                    payload: false
                });
            });
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

