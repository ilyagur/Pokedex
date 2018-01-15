import React, { Component } from 'react'

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

export default SuggestButton