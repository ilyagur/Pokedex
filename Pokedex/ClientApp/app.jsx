import React from 'react'
import ReactDOM from 'react-dom'
import Redux from 'redux'
import { Provider } from 'react-redux'

import App from './Containers/app'
import configureStore from './Store/configureStore'

const store = configureStore();

ReactDOM.render(
    <Provider store={ store }>
        <App />
    </Provider>,
    document.getElementById('root'));