import React from 'react';

export class ErrorMessages extends React.PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const {apiErrors} = this.props;

        return (
            <div className="card p-0 text-white border-danger">
                <h4 className="card-header bg-danger d-flex justify-content-center">Errors</h4>
                <div className="card-body p-1">
                    <ul className="list-group list-group-flush">
                        {apiErrors.map((x,i) =>
                            <li key={i} className="list-group-item">{x}</li>)}
                    </ul>

                </div>
            </div>
        )
    }
}
