import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Pager extends Component {
    render() {
        const { pokemonsPerPage, currentPageNumber, perPageOptions } = this.props.pager,
            pokemonsLength = this.props.pokemonsLength,
            changePageNumber = this.props.changePageNumber,
            changeItemsAmountPerPage = this.props.changeItemsAmountPerPage;


        let pagesLength = pokemonsLength / pokemonsPerPage, i, pageButtons = [], itemsPerPageButtons = [];

        if (pokemonsLength % pokemonsPerPage) {
            pagesLength += 1;
        }

        for (i = 1; i <= pagesLength; i += 1) {
            let changePageNumberFunc = (function (k) { return function () { changePageNumber(k); } })(i);
            let isPageSelected = (function (k) { return function () { return currentPageNumber === k ? 'active' : ''; };})(i);

            pageButtons.push(
                <li key={i} className={isPageSelected()}>
                    <a href="#" onClick={changePageNumberFunc} className="btn btn-outline-primary">{i}</a>
                </li>
            );
        }

        for (i = 0; i < perPageOptions.length; i++) {
            let perPageOption = perPageOptions[i];
            let isSelectedPerPageOption = (function (k) { return function () { return pokemonsPerPage === perPageOption ? 'active' : '' }; })(i);
            let changeItemsAmountPerPageFunc = (function (k) { return function () { changeItemsAmountPerPage(k) } })(perPageOption);

            itemsPerPageButtons.push(
                <li key={i} className={isSelectedPerPageOption()}>
                    <a href="#" onClick={changeItemsAmountPerPageFunc} className="btn btn-outline-primary">{perPageOption}</a>
                </li>
            );
        }

        return (
            <div className="row">
                <div className="col-xs-2 col-md-2">
                    <ul className="pagination">
                        {pageButtons}
                    </ul>
                </div>
                <div className="col-xs-offset-8 col-md-offset-8 col-xs-2 col-md-2">
                    <ul className="pagination">
                        {itemsPerPageButtons}
                    </ul>
                </div>
            </div>
        );
    }
}

Pager.propTypes = {
    pokemonsLength: PropTypes.number.isRequired,
    pager: PropTypes.object.isRequired
}

export default Pager