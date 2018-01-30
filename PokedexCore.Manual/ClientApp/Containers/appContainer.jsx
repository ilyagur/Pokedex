import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

import * as UserActions from './../Actions/userActions'

import Header from './headerContainer'
import Body from './bodyContainer'

class App extends Component {
    render() {
        const { user, userActions } = this.props;

        return (
            <div>
                <Header user={user} userActions={userActions} />
                <Body />
            </div>
            )
    }
}

function mapStateToProps(state) {
    return {
        user: state.user,
    };
}

function mapDispatchToProps(dispatch) {
    return {
        userActions: bindActionCreators(UserActions, dispatch),
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(App)