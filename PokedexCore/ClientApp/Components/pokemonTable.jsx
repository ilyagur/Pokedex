import React, { Component } from 'react'

import PokemonCard from './pokemonCard'
import Pager from './pager'

class PokemonTable extends Component {
    componentDidMount() {
        this.props.pageActions.changePageNumber(1);
    }
    render() {
        const pager = this.props.pager,
            { pokemonsPerPage, currentPageNumber } = pager,
            changePageNumber = this.props.pageActions.changePageNumber,
            changeItemsAmountPerPage = this.props.pageActions.changeItemsAmountPerPage,
            pokemons = this.props.pokemons;

        let pokemonsLength = pokemons.length, i, j = 0, k = 0, rows = [], row = [];

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

        var pagerComponentOptions = {
            pokemonsLength,
            pager,
            changePageNumber,
            changeItemsAmountPerPage
        };

        return (
            <div className="container">
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
                <Pager options={pagerComponentOptions} />
            </div>
            );
    }
}

export default PokemonTable