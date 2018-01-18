import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonsPerPage extends Component {
    render() {
        const { perPageOptions, pokemonsPerPage, changeItemsAmountPerPage } = this.props;

        return (
            <ul className="pagination">
                {
                    perPageOptions.map((o, i) => {
                        return (
                            <li key={i} className={o === pokemonsPerPage ? 'active' : undefined} >
                                <a href="#" onClick={changeItemsAmountPerPage.bind(this, o)} className="btn btn-outline-primary">{o}</a>
                            </li>
                        )
                    })}
            </ul>
        )
    }
}

PokemonsPerPage.propTypes = {
    perPageOptions: PropTypes.array.isRequired,
    pokemonsPerPage: PropTypes.number.isRequired,
    changeItemsAmountPerPage: PropTypes.func.isRequired,
}

export default PokemonsPerPage