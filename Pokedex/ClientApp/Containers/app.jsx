import React, { Component } from 'react'
import { connect } from 'react-redux'

class App extends Component {
    render() {
        const pokemon = this.props.pokemon;

        return (
            <div>
                {pokemon.name}
                {pokemon.color}
            </div>
            );
    }
}

function mapStateToProps(state) {
    return {
        pokemon: state.pokemon
    };
}

export default connect(mapStateToProps)(App);