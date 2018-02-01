import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as UserActions from './../Actions/userActions'

import Header from './headerContainer'
import Body from './bodyContainer'

class App extends Component {
    render() {
        const { userContext, userActions } = this.props;

        return (
            <div>
                <Header userContext={userContext} userActions={userActions} />
                <Body />
            </div>
            )
    }
}

function mapStateToProps(state) {
    return {
        userContext: state.userContext,
    };
}

function mapDispatchToProps(dispatch) {
    return {
        userActions: bindActionCreators(UserActions, dispatch),
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(App)