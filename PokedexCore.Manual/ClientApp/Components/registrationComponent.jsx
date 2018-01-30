import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Registration extends Component {
    render() {
        const {
            hideRegistrationDialog,
            isRegistrationDialogVisible,
        } = this.props;

        const style = { display: isRegistrationDialogVisible ? 'block' : 'none' };

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
                            <p>Registration Body</p>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary">Save changes</button>
                            <button onClick={hideRegistrationDialog} type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

Registration.propTypes = {
    hideRegistrationDialog: PropTypes.func.isRequired,
    isRegistrationDialogVisible: PropTypes.bool.isRequired,
}

export default Registration