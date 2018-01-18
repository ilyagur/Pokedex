import React, { Component } from 'react'
import PropTypes from 'prop-types'

import PokemonType from './pokemonType'

class PokemonCard extends Component {
    render() {
        const pokemon = this.props.pokemon

        return (

            <div className="col-xs-6 col-md-3">
                <div className="panel panel-default">
                    <div className="panel-heading">{pokemon.name}</div>
                    <div className="panel-body">
                        <img className="pokemon-avatar" src={pokemon.sprites.front_default} /> 
                    </div>
                    <div className="panel-footer">
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