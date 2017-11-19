import React, { Component } from 'react'
import { connect } from 'react-redux'

class App extends Component {
    render() {
        const pokemons = this.props.pokemons;

        return (
            <ul>
                {pokemons.map(pokemon => {
                    <li>{pokemon.name} {pokemon.weight}</li>
                })}
            </ul>
            );
    }
}

function mapStateToProps(state) {
    return {
        pokemons
    };
}

export default connect(mapStateToProps)(App);