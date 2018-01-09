import React, { Component } from 'react'
import PropTypes from 'prop-types'

class PokemonType extends Component {
    render() {
        let types = this.props.types
        return (
                <div className="row">
                {
                    types.map((type) => {
                        let typeName = type.type.name;
                        switch (typeName) {
                            case 'rock': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            case 'ground': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            case 'fire': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-danger">{typeName}</span></h5>)
                            case 'poison': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-warning">{typeName}</span></h5>)
                            case 'grass': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-success">{typeName}</span></h5>)
                            case 'water': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-primary">{typeName}</span></h5>)
                            case 'flying': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-info">{typeName}</span></h5>)
                            case 'bug': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            case 'normal': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            case 'fairy': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            case 'electric': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-info">{typeName}</span></h5>)
                            case 'fighting': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-danger">{typeName}</span></h5>)
                            case 'psychic': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-info">{typeName}</span></h5>)
                            case 'ice': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-info">{typeName}</span></h5>)
                            case 'ghost': return (<h5 className="col-xs-3 col-lg-3" key={type.slot}><span className="label label-default">{typeName}</span></h5>)
                            default: return (<h4 key={type.slot}><span>{type.type.name}</span></h4>)
                        }
                    })
                }
                </div>
            )
    }
}

PokemonType.propTypes = {
    types: PropTypes.array.isRequired
}

export default PokemonType