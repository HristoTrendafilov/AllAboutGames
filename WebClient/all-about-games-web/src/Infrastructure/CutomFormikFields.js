import React, {useEffect, useState} from 'react';
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

export const SelectField = ({label, isMulti, placeholder, options, customClassName, ...props}) => {
    const [field, meta, {setValue, setTouched}] = useField(props);
    const [selectedValue, setSelectedValue] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [selectOptions, setSelectOptions] = useState([]);

    useEffect(() => {
        let resultArr = [];
        for (let i = 0; i < options.length; i++) {
            const {optionsName, optionsValue} = options[i];
            let firstChar = optionsName[0].toUpperCase();
            let innerObject = {options: []};
            if (resultArr.some(x => x.label === firstChar)) {
                const curObj = resultArr.find(x => x.label === firstChar);
                curObj.options.push({label: optionsName, value: optionsValue})
            } else {
                innerObject.label = firstChar;
                innerObject.options.push({label: optionsName, value: optionsValue});
                resultArr.push(innerObject);
            }
        }

        const selectOptions = [...resultArr].sort((a, b) =>
            a.label > b.label ? 1 : -1,
        );

        setSelectOptions(selectOptions);
        setIsLoading(false);
    }, [options])


    const onChange = (option) => {
        if(isMulti){
            setValue(option.map(x => x.value))
        }
        else{
            setValue(option.value);
        }

        setSelectedValue(option)
    };

    return (
        <div className={customClassName}>
            {label && <label className="form-label justify-content-center d-flex fw-bold text-info">{label}</label>}

            <Select
                {...field} {...props}
                name={field.name}
                isMulti={isMulti || false}
                placeholder={placeholder}
                value={selectedValue}
                defaultValue={selectOptions.find((option) => option.value === field.value)}
                options={selectOptions}
                onChange={onChange}
                onBlur={setTouched}
                isClearable={true}
                closeMenuOnSelect={!isMulti}
                isLoading={isLoading}
            />
            {meta.touched && meta.error &&
            <div className="text-danger justify-content-center d-flex">{meta.error}</div>}
        </div>
    );
};
