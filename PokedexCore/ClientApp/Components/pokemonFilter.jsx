import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonFilter extends Component {
    render() {
        const { typeFilters, selectedTypeFilter, changePokemonTypeFilter, filterSpinnerVisible } = this.props;

        const spinner = (
            filterSpinnerVisible ? (
                <img src="sfloading.gif" />
            ) : (<div></div>)
            );

        return (
            <div className="btn-group btn-group-sm" role="group">
                {spinner}
                {
                    typeFilters.map((f, i) => {
                        return (
                            (f === selectedTypeFilter) ? (
                                <button disabled={filterSpinnerVisible} key={i} type="button" className="btn btn-success">{f}</button>
                            ) : (
                                    <button disabled={filterSpinnerVisible}  key={i} type="button" onClick={changePokemonTypeFilter.bind(this, f)} className="btn btn-default">{f}</button>
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
    filterSpinnerVisible: PropTypes.bool.isRequired,
}

export default PokemonFilter