import React, { Component } from 'react'
import PropTypes from 'prop-types'

class SearchPanel extends Component {
    constructor(props) {
        super(props);

        this.state = {
            pokemonName: ''
        };
    }
    updateValue(evt) {
        this.setState({
            pokemonName: evt.target.value
        });
    }
    render() {

        let { searchSpinnerVisible, searchPokemonByName } = this.props;

        return (
            <div className="row">
                <div className="col-lg-6">
                    {
                        searchSpinnerVisible ? (
                            <img src="sfloading.gif" />
                        ) : (
                                <div className="input-group">
                                    <span className="input-group-btn">
                                        <button className="btn btn-default" onClick={evt => searchPokemonByName(this.state.pokemonName)} type="button">Go!</button>
                                    </span>
                                    <input type="text" value={this.state.pokemonName} onChange={evt => this.updateValue(evt)} className="form-control" placeholder="Search for..." />
                                </div>
                            )
                    }
                </div>
            </div>
        );
    }
}

SearchPanel.propTypes = {
    searchSpinnerVisible: PropTypes.bool.isRequired,
    searchPokemonByName: PropTypes.func.isRequired,
}

export default SearchPanel