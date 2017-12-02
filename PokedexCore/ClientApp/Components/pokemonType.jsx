import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonType extends Component {
    render() {
        let types = this.props.types
        return types.map((type) => {
            let typeName = type.type.name;
            switch (typeName) {
                case 'ground': return (<h4 key={type.slot}><span className="label label-default">{typeName}</span></h4>)
                case 'fire': return (<h4 key={type.slot}><span className="label label-danger">{typeName}</span></h4>)
                default: return (<h4 key={type.slot}><span>{type.type.name}</span></h4>)
            }
        })
    }
}

PokemonType.propTypes = {
    types: PropTypes.array.isRequired
}

export default PokemonType