import React from 'react';
import {useField} from 'formik';

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

export const CheckboxField = ({ label, children, customClassName, ...props }) => {
    const [field, meta] = useField({ ...props });

    return (
        <div className={customClassName}>
            <input className="form-check-input" type="checkbox" {...field} {...props}/>
            <label className="form-check-label p-lg-2">
                {label}
            </label>
            {meta.touched && meta.error &&
            <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};
