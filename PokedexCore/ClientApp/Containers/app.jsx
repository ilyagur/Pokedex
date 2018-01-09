import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as PageActions from './../Actions/Page'

import PokemonTable from './../Components/pokemonTable'

class App extends Component {
    render() {
        const pokemons = this.props.pokemons,
            pager = this.props.pager,
            pageActions = this.props.pageActions;

        return (
            <div>
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