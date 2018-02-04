import React, { Component } from 'react'

export interface props {

}

export interface state {

}

class Registration extends Component<any, any> {
    constructor(props) {
        super(props);

        this.state = {
            Email: '',
            Password: '',
            FirstName: '',
            LastName: '',
            Location: '',
        }
    }
    updateValue(prop, evt) {
        this.setState({
            [prop]: evt.target.value
        });
    }
    render() {
        const {
            hideRegistrationDialog,
            isRegistrationDialogVisible,
            fetchStatus,
            registrate,
            responseMessage,
        } = this.props;

        const style = { display: isRegistrationDialogVisible ? 'block' : 'none' };

        const footer = fetchStatus == 'PENDING' ? (
            <div className="modal-footer">
                <img src="spinner.gif" />
            </div>
        ) : (
                <div className="modal-footer">
                    <button onClick={registrate.bind(this, this.state)} type="button" className="btn btn-primary">Registrate</button>
                    <button onClick={hideRegistrationDialog} type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            )

        const validationMessageFor = (prop) => {
            return responseMessage && responseMessage.hasOwnProperty(prop) ? (
                <div>
                    <ul>
                        {
                            responseMessage[prop].map((er, i) => {
                                return (
                                    <li key={i}><span className="badge badge-secondary">{er}</span></li>
                                )
                            })
                        }
                    </ul>
                </div>
            ) : (
                    <div></div>
                )
        }

        return (
            <div className="modal" style={style}>
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Registration</h5>
                            <button onClick={hideRegistrationDialog} type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="form-group">
                                    <label>Email address</label>
                                    <input value={this.state.Email} onChange={evt => this.updateValue('Email', evt)} type="text" className="form-control" placeholder="Enter email" />
                                    {validationMessageFor('Email')}
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input value={this.state.Password} onChange={evt => this.updateValue('Password', evt)} type="password" className="form-control" placeholder="Password" />
                                    {validationMessageFor('Password')}
                                </div>
                                <div className="form-group">
                                    <label>Email address</label>
                                    <input value={this.state.FirstName} onChange={evt => this.updateValue('FirstName', evt)} type="text" className="form-control" placeholder="Enter first name" />
                                    {validationMessageFor('FirstName')}
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input value={this.state.LastName} onChange={evt => this.updateValue('LastName', evt)} type="text" className="form-control" placeholder="Enter last name" />
                                    {validationMessageFor('LastName')}
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input value={this.state.Location} onChange={evt => this.updateValue('Location', evt)} type="text" className="form-control" placeholder="Your location" />
                                    {validationMessageFor('Location')}
                                </div>
                            </form>
                        </div>
                        {footer}
                    </div>
                </div>
            </div>
        )
    }
}

export default Registration