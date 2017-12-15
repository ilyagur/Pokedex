import React from 'react'
import ReactDOM from 'react-dom'
import Redux from 'redux'
import { Provider } from 'react-redux'

import App from './Containers/app'
import configureStore from './Store/configureStore'
import { getPokemons } from './Actions/Page'

const store = configureStore();

store.dispatch(getPokemons(22, 0));

ReactDOM.render(
    <Provider store={ store }>
        <App />
    </Provider>,
    document.getElementById('root'));