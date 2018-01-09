import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Pager extends Component {
    render() {
        const { pokemonsPerPage, currentPageNumber, perPageOptions } = this.props.options.pager,
            pokemonsLength = this.props.options.pokemonsLength,
            changePageNumber = this.props.options.changePageNumber,
            changeItemsAmountPerPage = this.props.options.changeItemsAmountPerPage;

        var PrevPage = function () {
            changePageNumber(currentPageNumber - 1);
        };
        var NextPage = function () {
            changePageNumber(currentPageNumber + 1);
        }

        return (
            <div className="row">
                <div className="col-xs-2 col-md-2">
                    <nav aria-label="Page navigation">
                        <ul className="pagination">
                            {
                                currentPageNumber > 1 ?
                                    <li>
                                        <a href="#" onClick={PrevPage} aria-label="Previous">
                                            <span aria-hidden="true">&laquo;</span>
                                        </a>
                                    </li>
                                    : null
                            }
                            <li>
                                <a href="#" onClick={NextPage} aria-label="Next">
                                    <span aria-hidden="true">&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div>
                <div className="col-xs-offset-8 col-md-offset-8 col-xs-2 col-md-2">
                    <ul className="pagination">
                        {PrepareItemsPerPageButtons(perPageOptions, pokemonsPerPage, changeItemsAmountPerPage)}
                    </ul>
                </div>
            </div>
        );
    }
}

function PrepareItemsPerPageButtons(perPageOptions, pokemonsPerPage, changeItemsAmountPerPage) {
    let i, itemsPerPageButtons = [];

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

    return itemsPerPageButtons;
}

//Pager.propTypes = {
//    pokemonsLength: PropTypes.number.isRequired,
//    pager: PropTypes.object.isRequired
//}

export default Pager