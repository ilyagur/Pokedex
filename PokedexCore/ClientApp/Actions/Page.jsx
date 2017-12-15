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
    return (dispatch) => {
        dispatch({
            type: Constants.CHANGE_PAGE_NUMBER,
            payload: pageNumber
        });
    }
}

export function changeItemsAmountPerPage(amout) {
    return (dispatch) => {
        dispatch({
            type: Constants.CHANGE_ITEMS_AMOUNT_PER_PAGE,
            payload: amout
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

export function getPokemons(count, skip) {
    return (dispatch) => {
        return fetch(`https://localhost:44365/api/Pokemon/GetPokemons/${count}/${skip}`)
            .then(
                response => response.json(),
                error => console.log(error)
            )
            .then(json => dispatch(receivePokemons(json)))
    };
}