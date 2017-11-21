import React, { Component } from 'react'

import PokemonCard from './pokemonCard'

class PokemonTable extends Component {
    render() {
        let pokemons = this.props.pokemons, len = pokemons.length, i, j = 0, k = 0, rows = [], row = [];

        for (i = 0; i < len; i++) {
            row[j++] = pokemons[i];

            if (row.length === 4) {
                rows[k++] = row;
                row = [];
                j = 0;
            }

            if ((i + 1) === len && 0 < row.length && row.length < 4) {
                rows[k++] = row;
            }
        }

        i = 0;

        return (
            <div className="container">
                {
                    rows.map((row) => {
                        return (
                            <div key={i++} className="row vert-offset-top-3">
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
            );
    }
}

export default PokemonTable