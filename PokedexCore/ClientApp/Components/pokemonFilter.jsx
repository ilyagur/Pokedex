import React, { Component } from 'react'

class PokemonFilter extends Component {
    render() {
        return (
            <div className="row vert-offset-top-1">
                <div className="btn-group btn-group-sm" role="group">
                    {
                        this.props.typeFilters.map((f, i) => {
                            return (
                                (f === this.props.selectedTypeFilter) ? (
                                    <button key={i} type="button" className="btn btn-success">{f}</button>
                                ) : (
                                    <button key={i} type="button" onClick={this.props.changePokemonTypeFilter.bind(this, f)} className="btn btn-default">{f}</button>
                                    )
                            )
                        })
                    }
                </div>
            </div>
        );
    }
}

export default PokemonFilter