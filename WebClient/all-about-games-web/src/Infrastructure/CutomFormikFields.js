import React from 'react';
import {useField} from 'formik';

export const TextField = ({label, customClassName, ...props}) => {
    const [field, meta] = useField(props);

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold text-info">{label}</label>}
            <input
                className={`form-control ${meta.touched && meta.error ? "border-danger" : "border-info"}`} {...field} {...props} />
            {meta.touched && meta.error &&
                <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};

export const DateField = ({label, customClassName, ...props}) => {
    const [field, meta] = useField(props);

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold text-info">{label}</label>}
            <input className={`form-control ${meta.touched && meta.error ? "border-danger" : "border-info"}`}
                   type="date" {...field} {...props} />
            {meta.touched && meta.error &&
                <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};

export const CheckboxField = ({label, children, customClassName, ...props}) => {
    const [field, meta] = useField({...props});

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

export const SelectField = ({label, options, customClassName, ...props}) => {
    const [field, meta] = useField(props);

    let resultObj = {};
    for (let i = 0; i < options.length; i++) {
        const {OptionsName, OptionsValue} = options[i];
        let firstChar = OptionsName[0].toUpperCase();
        let innerArr = [];
        if (resultObj[firstChar] === undefined) {
            innerArr.push({OptionsName, OptionsValue});
            resultObj[firstChar] = innerArr
        } else {
            resultObj[firstChar].push({OptionsName, OptionsValue})
        }
    }

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold text-info">{label}</label>}
            <select
                className={`form-select ${meta.touched && meta.error ? "border-danger" : "border-info"}`} {...field} {...props}>
                <option value={0}>---</option>
                { Object.keys(resultObj).map((keyName, i) => (
                    <optgroup key={keyName} label={keyName}>
                        {
                            resultObj[keyName].map((arrayObject) => (
                                <option key={arrayObject.OptionsValue} value={arrayObject.OptionsValue}>
                                    {arrayObject.OptionsName}
                                </option>
                            ))
                        }
                    </optgroup>
                ))}
            </select>
            {meta.touched && meta.error &&
                <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};
