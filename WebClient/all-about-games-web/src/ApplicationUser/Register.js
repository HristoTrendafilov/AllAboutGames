import {Form, Formik} from 'formik';
import React, {useEffect, useState} from 'react';
import * as Validations from '../Infrastructure/ValidationModels';
import {SendRequest} from '../Infrastructure/Server';
import {RegisterUserRequest} from '../Infrastructure/Dto'
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {DateField, SelectField, TextField} from "../Infrastructure/CutomFormikFields";

export function RegisterUser() {

    const [state, setState] = useState({model: RegisterUserRequest.UserDTO, countries: [], stateErrors: []});

    useEffect( () => {
        (async () => {
            const response = await SendRequest('GetAllCountriesRequest', {});
            if (response.isFailed) {
                setState({...state, stateErrors: response.errors});
                return;
            }

            setState({...state,countries: response.model.Countries})
        })();
    }, [])

    const HandleSubmit = async (data) => {
        const request = RegisterUserRequest;
        request.UserDTO = {...data};

        const response = await SendRequest('RegisterUserRequest', request);
        if (response.isFailed) {
            setState({...state,stateErrors: response.errors});
            return;
        }

        window.location.href = '/user/login?hasRegistered=true'
    }

    return (
        <div className='d-flex justify-content-center mt-4'>
            <div className="card border-info border-3 bg-transparent" style={{width: 600}}>
                <h4 className="card-header text-warning border-3 border-info">Registration</h4>
                <div className="card-body pb-0">

                    <Formik
                        initialValues={{...state.model}}
                        onSubmit={async (values) => {
                            await HandleSubmit(values)
                        }}
                        validationSchema={Validations.RegisterUserValidationSchema}
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
