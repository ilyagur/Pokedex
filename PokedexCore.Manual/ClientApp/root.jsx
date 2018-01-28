import React, { Component } from 'react'
import ReactDOM from 'react-dom'

class Test extends Component {
    render() {
        return (
            <div>
                <h3>Test Text</h3>
            </div>
            )
    }
}

ReactDOM.render(
    <Test />,
    document.getElementById('root')
);