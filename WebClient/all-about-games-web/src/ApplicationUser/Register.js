import {Field, Form, Formik} from 'formik';
import React from 'react';
import * as Validations from '../Infrastructure/ValidationModels';
import {SendRequest} from '../Infrastructure/Server';
import {RegisterUserRequest} from '../Infrastructure/Dto'
import {ErrorMessages} from "../Infrastructure/ErrorMessages";

export class RegisterUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            isLoading: false,
            stateErrors: []
        }
    }

    handleSubmit = async (data) => {
        const request = RegisterUserRequest;
        request.UserDTO = {...data};

        const response = await SendRequest('RegisterUserRequest', request);
        if (response.isFailed) {
            this.setState({stateErrors: response.errors});
            return;
        }
    }

    render() {
        const model = RegisterUserRequest.UserDTO;
        const {stateErrors} = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card border-info border-4" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body pb-0">

                        <Formik
                            initialValues={{...model}}
                            onSubmit={async (values) => {
                                await this.handleSubmit(values)
                            }}
                            validationSchema={Validations.RegisterUserValidationSchema}
                        >
                            {({isSubmitting, errors, touched}) => (
                                <Form>

                                    <div className="row">

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex fw-bold">Username</label>
                                            <Field
                                                name='username'
                                                type='input'
                                                className="form-control"/>
                                            {errors.username && touched.username &&
                                            <div style={{color: 'red'}}>{errors.username}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex fw-bold">Password</label>
                                            <Field
                                                name='password'
                                                type='password'
                                                className="form-control"/>
                                            {errors.password && touched.password &&
                                            <div style={{color: 'red'}}>{errors.password}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center fw-bold">Date of
                                                birth</label>
                                            <Field
                                                name="dateOfBirth"
                                                type="date"
                                                className="form-control"/>
                                            {errors.dateOfBirth && touched.dateOfBirth &&
                                            <div style={{color: 'red'}}>{errors.dateOfBirth}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center fw-bold">Country</label>
                                            <Field as='select' name='countryID' className="form-select">
                                                <option value="0">Select country</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </Field>
                                            {errors.countryID && touched.countryID &&
                                            <div style={{color: 'red'}}>{errors.countryID}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-12">
                                            <label className="form-label d-flex justify-content-center fw-bold">Email</label>
                                            <Field
                                                name="email"
                                                type="email"
                                                className="form-control"/>
                                            {errors.email && touched.email &&
                                            <div style={{color: 'red'}}>{errors.email}</div>}
                                        </div>

                                        <div className="col-xl-12 text-center mb-3">
                                            <button
                                                type="submit"
                                                className="btn btn-outline-primary w-50"
                                                disabled={isSubmitting}>
                                                Register
                                            </button>
                                        </div>

                                        {stateErrors.length > 0 && <ErrorMessages apiErrors={stateErrors}/>}

                                    </div>

                                </Form>
                            )}
                        </Formik>

                    </div>
                </div>
            </div>
        );
    }
}
