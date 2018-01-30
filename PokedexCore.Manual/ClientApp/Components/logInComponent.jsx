import React, { Component } from 'react'
import PropTypes from 'prop-types'

class LogIn extends Component {
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
            logIn,
        } = this.props;

        const style = { display: isLoginDialogVisible ? 'block' : 'none' };

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
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input value={this.state.password} onChange={evt => this.updateValue('password', evt)} type="password" className="form-control" id="exampleInputPassword1" placeholder="Password" />
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button onClick={logIn.bind(this, this.state.email, this.state.password)} type="button" className="btn btn-primary">Save changes</button>
                            <button onClick={hideLogInDialog} type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

LogIn.propTypes = {
    hideLogInDialog: PropTypes.func.isRequired,
    isLoginDialogVisible: PropTypes.bool.isRequired,
}

export default LogIn