import React, { Component } from 'react'
import PropTypes from 'prop-types'

import PokemonCard from './pokemonCard'

class PokemonTable extends Component {
    render() {
        const { pokemons } = this.props;

        let pokemonsLength = pokemons.length, i, j = 0, k = 0, rows = [], row = [];

        if (pokemonsLength == 1 && pokemons[0] == null) {
            return (
                <div className="panel panel-default vert-offset-top-3">
                    <div className="panel-body">
                        No Pokemons.
                    </div>
                </div>
                );
        }

        for (i = 0; i < pokemonsLength; i++) {
            
            row[j++] = pokemons[i];

            if (row.length === 4) {
                rows[k++] = row;
                row = [];
                j = 0;
            }

            if ((i + 1) === pokemonsLength && 0 < row.length && row.length < 4) {
                rows[k++] = row;
            }
        }

        return (
            <div className="container">
                <div>
                    {
                        rows.map((row, r) => {
                            return (
                                <div key={r} className="row vert-offset-top-3">
                                    {
                                        row.map((pokemon) => {
                                            return (
                                                <PokemonCard pokemon={pokemon} key={pokemon.id} />
                                                );
                                        })
                                    }
                                </div>
                            );
                        })
                    }
                </div>
            </div>
            );
    }
}

PokemonTable.propTypes = {
    pokemons: PropTypes.array,
}

export default PokemonTable