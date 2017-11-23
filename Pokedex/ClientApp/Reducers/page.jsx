import * as Constants from './../Constants/Page'

const initialState = {
    pager: {
        pageNumber: 1,
        pokemonsPerPage: 6,
        typeFilters: [],
        selectedTypeFilter: null,
        perPageOptions: [6, 12, 18, 24, 32]
    }
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.CHANGE_PAGE_NUMBER: return Object.assign({}, state, { pageNumber: action.payload });
        default: return state;
    }
}