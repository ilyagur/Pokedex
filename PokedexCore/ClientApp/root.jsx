import React from 'react'
import ReactDOM from 'react-dom'
import Redux from 'redux'
import { BrowserRouter as Router, Route } from 'react-router-dom'
import { Provider } from 'react-redux'

import App from './Containers/app'
import configureStore from './Store/configureStore'

const store = configureStore();

ReactDOM.render(
    <Provider store={store}>
        <Router>
            <Route path="/:filter?" component={App} />
        </Router>
    </Provider>,
    document.getElementById('root'));