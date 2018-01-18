import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonPager extends Component {
    render() {
        const { currentPageNumber, changePageNumber } = this.props;

        return (

            <nav aria-label="Page navigation">
                <ul className="pagination">
                    {
                        currentPageNumber > 1 ?
                            <li>
                                <a href="#" onClick={changePageNumber.bind(this, (currentPageNumber - 1))} aria-label="Previous">
                                    <span aria-hidden="true">&laquo;</span>
                                </a>
                            </li>
                            : null
                    }
                    <li>
                        <a href="#" onClick={changePageNumber.bind(this, (currentPageNumber + 1))} aria-label="Next">
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </nav>
        );
    }
}

PokemonPager.propTypes = {
    currentPageNumber: PropTypes.number.isRequired,
    changePageNumber: PropTypes.func.isRequired,
}

export default PokemonPager