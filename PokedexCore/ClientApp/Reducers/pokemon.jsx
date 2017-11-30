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
        },
        {
            name: "spearow",
            weight: 295,
            sprites: {
                front_default: "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/21.png"
            },
            height: 10,
            id: 22,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
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
            id: 23,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
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
            id: 24,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
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
            id: 25,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
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
            id: 26,
            types: [
                {
                    slot: 1,
                    type: {
                        url: "https://pokeapi.co/api/v2/type/5",
                        name: 'fire'
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
            id: 27,
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

export default function reducer(state = initialState, action) {
    return state;
}