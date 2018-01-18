import * as Constants from './../Constants/All'

const initialState = {
    currentPageNumber: 1,
    pokemonsPerPage: 8,
    perPageOptions: [8, 16, 24, 32],
    pokemonsCount: 949,
    spinners: {
        suggestSpinnerVisible: false,
        searchSpinnerVisible: false
    }
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.CHANGE_PAGE_NUMBER: return Object.assign({}, state, { currentPageNumber: action.payload });
        case Constants.CHANGE_ITEMS_AMOUNT_PER_PAGE: return Object.assign({}, state, { pokemonsPerPage: action.payload });

        case Constants.SUGGEST_SPINNER_VISIBLE: return Object.assign({}, state, { spinners: Object.assign({}, state.spinners, { suggestSpinnerVisible: action.payload }) });

        case Constants.SEARCH_SPINNER_VISIBLE: return Object.assign({}, state, { spinners: Object.assign({}, state.spinners, { searchSpinnerVisible: action.payload }) });

        case Constants.CHANGE_POKEMON_TYPE_FILTER: return Object.assign({}, state, { selectedTypeFilter: action.payload });
        default: return state;
    }
}