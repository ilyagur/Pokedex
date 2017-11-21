import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonCard extends Component {
    render() {
        let pokemon = this.props.pokemon

        return (
            <div className="col-md-3">
                <div className="card border-primary">
                    <div className="row">
                        <div className="card-body col-md-6">
                            <img style={{ display: 'block', width: '150px', heigh: '150px' }} src={pokemon.sprites.front_default} /> 
                        </div>
                        <div className="card-body col-md-6">
                            <h3>{pokemon.name}</h3>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-6">
                            <span className="badge badge-pill badge-primary">Primary</span>
                            <span className="badge badge-pill badge-secondary">Secondary</span>
                        </div>
                        <div className="col-md-6">
                            <img src="/img/cropped-cropped-hearticon-compressor.png" />
                        </div>
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