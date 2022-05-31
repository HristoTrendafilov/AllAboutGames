import React from 'react';
import {Field} from "formik";

export class TextField extends React.PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const {label, name, type, errors, touched} = this.props;

        return (
            <div className="mb-3 col-xl-6">
                {label && <label className="form-label justify-content-center d-flex">{label}</label>}
                <Field
                    name={name}
                    type={type ? type : 'input'}
                    className="form-control"/>
                {errors.username && touched.username && <div style={{color: 'red'}}>{errors.username}</div>}
            </div>
        )
    }
}
