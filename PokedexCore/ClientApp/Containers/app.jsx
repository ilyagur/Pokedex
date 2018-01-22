import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'
import * as PokemonActions from './../Actions/Pokemon'

import Header from './header'
import Body from './body'

class App extends Component {
    render() {
        const { pokemons, pager, pageActions, pokemonActions } = this.props;

        return (
            <div>
                <Header />
                <Body pokemons={pokemons} pager={pager} pageActions={pageActions} pokemonActions={pokemonActions} />
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