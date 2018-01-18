import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonFilter extends Component {
    render() {
        const { typeFilters, selectedTypeFilter, changePokemonTypeFilter } = this.props;

        return (
            <div className="btn-group btn-group-sm" role="group">
                {
                    typeFilters.map((f, i) => {
                        return (
                            (f === selectedTypeFilter) ? (
                                <button key={i} type="button" className="btn btn-success">{f}</button>
                            ) : (
                                    <button key={i} type="button" onClick={changePokemonTypeFilter.bind(this, f)} className="btn btn-default">{f}</button>
                                )
                        )
                    })
                }
            </div>
        );
    }
}

PokemonFilter.propTypes = {
    typeFilters: PropTypes.array.isRequired,
    selectedTypeFilter: PropTypes.string,
    changePokemonTypeFilter: PropTypes.func.isRequired,
}

export default PokemonFilter