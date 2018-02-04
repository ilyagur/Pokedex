import * as React from 'react';
import { bindActionCreators, Dispatch } from 'redux'
import { connect } from 'react-redux'

import * as UserActions from './../Actions/userActions'

import Header from './headerContainer'
import Body from './bodyContainer'

interface appProps {
    userContext: Object,
    userActions: Object
}

class App extends React.Component<appProps, {}> {
    constructor(props: appProps) {
        super(props);
    }
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

interface State {
    userContext: Object
}

function mapStateToProps(state: State) {
    return {
        userContext: state.userContext,
    };
}

function mapDispatchToProps(dispatch: Dispatch<any>) {
    return {
        userActions: bindActionCreators(UserActions, dispatch),
    }
}

//export default connect(mapStateToProps, mapDispatchToProps)(App)

export function mergeProps(stateProps: Object, dispatchProps: Object, ownProps: Object) {
    return Object.assign({}, ownProps, stateProps, dispatchProps);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps,
    mergeProps)(App);