import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'

import PokemonTable from './../Components/pokemonTable'

class App extends Component {
    render() {
        const pokemons = this.props.pokemons;

        return (
            <div>
                <PokemonTable pokemons={ pokemons } />
            </div>
            );
    }
}

function mapStateToProps(state) {
    return {
        pokemons: state.pokemons.pokemons
    };
}

function mapDispatchToProps(dispatch) {
    return {
        pageActions: bindActionCreators(PageActions, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(App);