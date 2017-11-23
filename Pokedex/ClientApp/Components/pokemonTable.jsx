import React, { Component } from 'react'

import PokemonCard from './pokemonCard'
import Pager from './pager'

class PokemonTable extends Component {
    render() {
        const { pokemonsPerPage, pageNumber } = this.props.pager,
            changePageNumber = this.props.pageActions.changePageNumber;

        let pokemons = this.props.pokemons, pokemonsLength = pokemons.length, i, j = 0, k = 0, rows = [], row = [];

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

        i = 0;

        return (
            <div className="container">
                <span>Current page number is {pageNumber}</span>
                <div>
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
                <Pager pokemonsLength={pokemonsLength} pokemonsPerPage={pokemonsPerPage} changePageNumber={changePageNumber} pageNumber={pageNumber} />
            </div>
            );
    }
}

export default PokemonTable