import React, { Component } from 'react'
import PropTypes from 'prop-types'

import PokemonType from './pokemonType'

class PokemonCard extends Component {
    render() {
        let pokemon = this.props.pokemon

        return (
            <div className="col-xs-6 col-md-3">
                <div className="card">
                    <div className="card-header">
                        <h5 className="text-center">{pokemon.name}</h5>
                    </div>
                    <div className="card-body">
                        <img className="pokemon-avatar" src={pokemon.sprites.front_default} /> 
                    </div>
                    <div className="card-body">
                        <PokemonType types={pokemon.types} />
                    </div>
                </div>
            </div>
            )
    }
}

PokemonCard.propTypes = {
    pokemon: PropTypes.object.isRequired
}

export default PokemonCard