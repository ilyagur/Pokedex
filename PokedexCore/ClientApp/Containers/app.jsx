import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'
import * as PokemonActions from './../Actions/Pokemon'

import PokemonTable from './../Components/pokemonTable'
import SearchPanel from './../Components/searchPanel'
import SuggestButton from './../Components/suggestButton'
import PokemonFilter from './../Components/pokemonFilter'
import PokemonPager from './../Components/pokemonPager'
import PokemonsPerPage from './../Components/pokemonsPerPage'

class App extends Component {
    componentDidMount() {
        this.props.pageActions.changePageNumber(1);
    }
    render() {
        const {
            pokemons: {
                typeFilters,
                selectedTypeFilter,
                pokemons,
            },
            pager: {
                currentPageNumber,
                spinners: {
                    suggestSpinnerVisible,
                    searchSpinnerVisible,
                    filterSpinnerVisible,
                },
                perPageOptions,
                pokemonsPerPage,
            },
            pageActions: {
                suggestPokemons,
                searchPokemonByName,
                changeItemsAmountPerPage,
                changePageNumber,
            },
            pokemonActions: {
                changePokemonTypeFilter,
            }
        } = this.props;

        return (
            <div className="container">
                <div className="row vert-offset-top-1">
                    <div className="col-xs-offset-1 col-md-offset-1 col-md-xs-11 col-md-5">
                        <SuggestButton suggestSpinnerVisible={suggestSpinnerVisible} suggestPokemons={suggestPokemons} />
                    </div>
                    <div className="col-xs-offset-1 col-md-offset-1 col-md-xs-11 col-md-5">
                        <SearchPanel searchSpinnerVisible={searchSpinnerVisible} searchPokemonByName={searchPokemonByName} />
                    </div>
                </div>
                <div className="row vert-offset-top-1">
                    <div className="col-xs-offset-1 col-md-offset-1 col-xs-11 col-md-11">
                        <PokemonFilter typeFilters={typeFilters} changePokemonTypeFilter={changePokemonTypeFilter} selectedTypeFilter={selectedTypeFilter} filterSpinnerVisible={filterSpinnerVisible} />
                    </div>
                </div>
                <div className="row vert-offset-top-1">
                    <PokemonTable pokemons={pokemons} />
                </div>
                <div className="row vert-offset-top-1">
                    <div className="col-xs-2 col-md-2">
                        <PokemonPager changePageNumber={changePageNumber} currentPageNumber={currentPageNumber} />
                    </div>
                    <div className="col-xs-offset-8 col-md-offset-8 col-xs-2 col-md-2">
                        <PokemonsPerPage perPageOptions={perPageOptions} pokemonsPerPage={pokemonsPerPage} changeItemsAmountPerPage={changeItemsAmountPerPage} />
                    </div>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        pager: state.page,
        pokemons: state.pokemons
    };
}

function mapDispatchToProps(dispatch) {
    return {
        pageActions: bindActionCreators(PageActions, dispatch),
        pokemonActions: bindActionCreators(PokemonActions, dispatch),
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(App);