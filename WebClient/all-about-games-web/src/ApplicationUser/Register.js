import {Form, Formik} from 'formik';
import React, {useEffect, useState} from 'react';
import {SendRequest} from '../Infrastructure/Server';
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {DateField, SelectField, TextField} from "../Infrastructure/CutomFormikFields";
// noinspection ES6CheckImport
import {useNavigate} from "react-router-dom";
import * as Yup from "yup";

const initialValues = {
    username: '',
    password: '',
    repeatPassword: '',
    dateOfBirth: '',
    countryID: 0,
    email: '',
}

const ValidationSchema = Yup.object().shape({
    username: Yup.string()
        .min(3, 'Username must be between 3 and 50 characters long.')
        .max(50, 'Username must be between 3 and 50 characters long.')
        .required('username is required'),
    password: Yup.string()
        .min(5, "Your password must be longer than 5 characters.")
        .required('Password is required'),
    repeatPassword: Yup.string()
        .required('Repeat the password.')
        .oneOf([Yup.ref('password'), null], 'Passwords do not match!'),
    dateOfBirth: Yup.date()
        .required('birth date is required'),
    countryID: Yup.number()
        .min(1, 'country is required.')
        .required('country is required.'),
    email: Yup.string()
        .required('email is required.'),
});

export function RegisterUser() {

    const [state, setState] = useState({countries: [], stateErrors: []});
    const navigate = useNavigate();

    useEffect(() => {
        (async () => {
            const response = await SendRequest('GetCountriesRequest', {});
            if (response.isFailed) {
                setState({...state, stateErrors: response.errors});
                return;
            }

            const {countries} = response.model;
            setState({...state, countries: countries})
        })();
    }, [])

    const HandleSubmit = async (data) => {
        const request = {
            userDTO: data
        }

        const response = await SendRequest('RegisterUserRequest', request);
        if (response.isFailed) {
            setState({...state, stateErrors: response.errors});
            return;
        }

        navigate("/user/login?hasRegistered=true");
    }

    return (
        <div className='d-flex justify-content-center mt-4'>
            <div className="card border-info border-3 bg-transparent" style={{width: 600}}>
                <h4 className="card-header text-warning border-3 border-info">Registration</h4>
                <div className="card-body pb-0">

                    <Formik
                        initialValues={{...initialValues}}
                        onSubmit={async (values) => {
                            await HandleSubmit(values)
                        }}
                        validationSchema={ValidationSchema}
                    >
                        {({isSubmitting}) => (
                            <Form className="row">

                                <TextField
                                    customClassName="mb-3 col-xl-12"
                                    label="Username"
                                    name="username"
                                />

                                <TextField
                                    customClassName="mb-3 col-xl-6"
                                    label="Password"
                                    name="password"
                                    type="password"
                                />

                                <TextField
                                    customClassName="mb-3 col-xl-6"
                                    label="Repeat password"
                                    name="repeatPassword"
                                    type="password"
                                />

                                <TextField
                                    customClassName="mb-3 col-xl-12"
                                    label="Email"
                                    name="email"
                                    type="email"
                                />

                                <DateField
                                    customClassName="mb-3 col-xl-6"
                                    label="Date of birth"
                                    name="dateOfBirth"
                                />

                                <SelectField
                                    customClassName="mb-3 col-xl-6"
                                    name='countryID'
                                    label='Country'
                                    placeholder='Select country'
                                    options={state.countries}
                                />

                                <div className="col-xl-12 text-center mb-3">
                                    <button
                                        type="submit"
                                        className="btn btn-outline-warning w-50"
                                        disabled={isSubmitting}>
                                        Register
                                    </button>
                                </div>

                                {state.stateErrors.length > 0 && <ErrorMessages apiErrors={state.stateErrors}/>}

                            </Form>
                        )}
                    </Formik>

                </div>
            </div>
        </div>
    );
}
