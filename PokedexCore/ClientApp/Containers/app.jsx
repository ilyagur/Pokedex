import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'

import PokemonTable from  './../Components/pokemonTable'
import SearchPanel from   './../Components/searchPanel'
import SuggestButton from './../Components/suggestButton'

class App extends Component {
    render() {
        const pokemons = this.props.pokemons,
            pager = this.props.pager,
            pageActions = this.props.pageActions;

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
        pageActions: bindActionCreators(PageActions, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(App);