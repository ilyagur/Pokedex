import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'
import * as PokemonActions from './../Actions/Pokemon'

import PokemonTable from  './../Components/pokemonTable'
import SearchPanel from   './../Components/searchPanel'
import SuggestButton from './../Components/suggestButton'
import PokemonFilter from './../Components/pokemonFilter'

class App extends Component {
    render() {
        const { pokemons, pager, pageActions, pokemonActions } = this.props;

        return (
            <div>
                <div className="row vert-offset-top-1">
                    <div className="col-xs-offset-1 col-md-offset-1 col-md-xs-11 col-md-5">
                        <SuggestButton suggestSpinnerVisible={pager.spinners.suggestSpinnerVisible} suggestPokemons={pageActions.suggestPokemons} />
                    </div>
                    <div className="col-xs-offset-1 col-md-offset-1 col-md-xs-11 col-md-5">
                        <SearchPanel searchSpinnerVisible={pager.spinners.searchSpinnerVisible} searchPokemonByName={pageActions.searchPokemonByName} />
                    </div>
                </div>
                <PokemonFilter typeFilters={pokemons.typeFilters} changePokemonTypeFilter={pokemonActions.changePokemonTypeFilter} selectedTypeFilter={pokemons.selectedTypeFilter} />
                <PokemonTable pokemons={pokemons} pager={pager} pageActions={pageActions}/>
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