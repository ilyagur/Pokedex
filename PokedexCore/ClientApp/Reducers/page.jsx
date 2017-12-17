﻿import * as Constants from './../Constants/Page'

const initialState = {
    currentPageNumber: 1,
    pokemonsPerPage: 8,
    typeFilters: [],
    selectedTypeFilter: null,
    perPageOptions: [8, 16, 24, 32]
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case Constants.CHANGE_PAGE_NUMBER: return Object.assign({}, state, { currentPageNumber: action.payload });
        case Constants.CHANGE_ITEMS_AMOUNT_PER_PAGE: return Object.assign({}, state, { pokemonsPerPage: action.payload });
        default: return state;
    }
}