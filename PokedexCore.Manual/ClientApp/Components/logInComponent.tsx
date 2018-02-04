import React, { Component } from 'react'

class LogIn extends Component<any, any> {
    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: '',
        }
    }
    updateValue(prop, evt) {
        this.setState({
            [prop]: evt.target.value
        });
    }
    render() {

        const {
            hideLogInDialog,
            isLoginDialogVisible,
            fetchStatus,
            logIn,
            responseMessage,
        } = this.props;

        const style = { display: isLoginDialogVisible ? 'block' : 'none' };

        const footer = fetchStatus == 'PENDING' ? (
            <div className="modal-footer">
                <img src="spinner.gif" />
            </div>
        ) : (
                <div className="modal-footer">
                    <button onClick={logIn.bind(this, this.state.email, this.state.password)} type="button" className="btn btn-primary">Log In</button>
                    <button onClick={hideLogInDialog} type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
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
            <div className="modal" style={style} >
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Log In</h5>
                            <button onClick={hideLogInDialog} type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="form-group">
                                    <label>Email address</label>
                                    <input value={this.state.email} onChange={evt => this.updateValue('email', evt)} type="text" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
                                    {validationMessageFor('UserName')}
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input value={this.state.password} onChange={evt => this.updateValue('password', evt)} type="password" className="form-control" id="exampleInputPassword1" placeholder="Password" />
                                    {validationMessageFor('Password')}
                                </div>
                            </form>
                            {validationMessageFor('login_failure')}
                        </div>
                        {footer}
                    </div>
                </div>
            </div>
        )
    }
}

export default LogIn