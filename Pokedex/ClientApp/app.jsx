import React from 'react'
import ReactDOM from 'react-dom'
import Redux from 'redux'
import { Provider } from 'react-redux'

import App from './Containers/app'
import configureStore from './Store/configureStore'

const initialState = {
    pokemons: [
        {
            name: "sandslash",
            weight: 295,
            sprites: {
                front_default: "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/28.png"
            },
            height: 10,
            id: 28,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: "ground"
                    }
                }
            ]
        },
        {
            name: "vulpix",
            weight: 295,
            sprites: {
                front_default: "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/37.png"
            },
            height: 10,
            id: 37,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: "ground"
                    }
                }
            ]
        },
        {
            name: "spearow",
            weight: 295,
            sprites: {
                front_default: "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/21.png"
            },
            height: 10,
            id: 21,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
                    }
                }
            ]
        }
    ]
}

const store = configureStore(initialState);

ReactDOM.render(
    <Provider store={ store }>
        <App />
    </Provider>,
    document.getElementById('root'));