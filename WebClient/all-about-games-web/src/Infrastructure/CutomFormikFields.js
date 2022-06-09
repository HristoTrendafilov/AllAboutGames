import React from 'react';
import {useField, ErrorMessage} from 'formik';

export const TextField = ({label, customClassName, ...props}) => {
    const [field, meta] = useField(props);

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold">{label}</label>}
            <input className="form-control" {...field} {...props} />
            {meta.touched && meta.error &&
            <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};
