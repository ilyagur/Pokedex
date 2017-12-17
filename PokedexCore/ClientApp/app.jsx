import React from 'react'
import ReactDOM from 'react-dom'
import Redux from 'redux'
import { BrowserRouter as Router, Route } from 'react-router-dom'
import { Provider } from 'react-redux'

import App from './Containers/app'
import configureStore from './Store/configureStore'
import { getPokemons } from './Actions/Page'

const store = configureStore();

// TODO: make server render
store.dispatch(getPokemons(22, 0));

ReactDOM.render(
    <Provider store={store}>
        <Router>
            <Route path="/:filter?" component={App} />
        </Router>
    </Provider>,
    document.getElementById('root'));