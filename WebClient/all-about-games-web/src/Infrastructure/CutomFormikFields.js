import React, {useState} from 'react';
import {useField} from 'formik';
import Select from "react-select";

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
    const [selectedOption, setSelectedOption] = useState(null);

    let resultArr = [];
    for (let i = 0; i < options.length; i++) {
        const {optionsName, optionsValue} = options[i];
        let firstChar = optionsName[0].toUpperCase();
        let innerObject = { options: [] };
        if(resultArr.some(x => x.label === firstChar)){
            const curObj = resultArr.find(x => x.label === firstChar);
            curObj.options.push({label: optionsName, value: optionsValue})
        }else{
            innerObject.label = firstChar;
            innerObject.options.push({label: optionsName, value: optionsValue});
            resultArr.push(innerObject);
        }
    }

    const selectOptions = [...resultArr].sort((a, b) =>
        a.name > b.name ? 1 : -1,
    );

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold text-info">{label}</label>}

            <Select className={`${meta.touched && meta.error ? "border-danger" : "border-info"}`}
                    options={selectOptions}
                    defaultValue={selectedOption}
                    onChange={(e) => setSelectedOption(e)}
                    {...field} {...props}/>

            {meta.touched && meta.error &&
                <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};
