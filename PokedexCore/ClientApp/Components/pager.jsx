import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Pager extends Component {
    render() {
        const { pokemonsLength, pokemonsPerPage, changePageNumber, pageNumber } = this.props;

        let pagesLength = pokemonsLength / pokemonsPerPage, i, pageButtons = [];

        if (pokemonsLength % pokemonsPerPage) {
            pagesLength += 1;
        }

        for (i = 1; i <= pagesLength; i += 1) {
            pageButtons.push(
                <li key={i} className="page-item">
                    <button type="button" onClick={() => changePageNumber(i)} className="btn btn-outline-primary">{i}</button>
                </li>
            );
        }

        return (
            <div>
                <ul className="pagination">
                    {pageButtons}
                </ul>
            </div>
            //<div>
            //<ul className="pagination">
            //    <li className="page-item disabled">
            //        <a className="page-link" href="#">&laquo;</a>
            //    </li>
            //    <li className="page-item active">
            //        <a className="page-link" href="#">1</a>
            //    </li>
            //    <li className="page-item">
            //        <a className="page-link" href="#">2</a>
            //    </li>
            //    <li className="page-item">
            //        <a className="page-link" href="#">3</a>
            //    </li>
            //    <li className="page-item">
            //        <a className="page-link" href="#">4</a>
            //    </li>
            //    <li className="page-item">
            //        <a className="page-link" href="#">5</a>
            //    </li>
            //    <li className="page-item">
            //        <a className="page-link" href="#">&raquo;</a>
            //    </li>
            //</ul>
            //</div>
        );
    }
}

Pager.propTypes = {
    pokemonsLength: PropTypes.number.isRequired,
    pokemonsPerPage: PropTypes.number.isRequired,
    changePageNumber: PropTypes.func.isRequired,
    pageNumber: PropTypes.number.isRequired,
}

export default Pager