import React, { Component } from 'react'
import PropTypes from 'prop-types'

class SuggestButton extends Component {
    render() {

        let { suggestSpinnerVisible, suggestPokemons } = this.props;

        return (
            suggestSpinnerVisible ? (
                <img src="sfloading.gif" />
            ) : (
                    <button type="button" onClick={suggestPokemons} className="btn btn-danger">Suggest Pokemon</button>
                )
        );
    }
}

SuggestButton.propTypes = {
    suggestSpinnerVisible: PropTypes.bool.isRequired,
    suggestPokemons: PropTypes.func.isRequired,
}

export default SuggestButton