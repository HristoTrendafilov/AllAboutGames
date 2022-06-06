import {Field, Form, Formik} from 'formik';
import React from 'react';
import axios from "axios";
import * as Validations from '../Infrastructure/ValidationModels';
import {SendRequest} from '../Infrastructure/Server';

export class RegisterUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            model: {
                username: '',
                password: '',
                dateOfBirth: '',
                countryID: 0,
                email: ''
            }
        }
    }

    handleSubmit = async (data) => {
        const response = SendRequest('RegisterUserRequest', data);
    }

    render() {
        const {model} = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body">

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
                                            <label className="form-label justify-content-center d-flex">Username</label>
                                            <Field
                                                name='username'
                                                type='input'
                                                className="form-control"/>
                                            {errors.username && touched.username &&
                                                <div style={{color: 'red'}}>{errors.username}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex">Password</label>
                                            <Field
                                                name='password'
                                                type='password'
                                                className="form-control"/>
                                            {errors.password && touched.password &&
                                                <div style={{color: 'red'}}>{errors.password}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Date of
                                                birth</label>
                                            <Field
                                                name="dateOfBirth"
                                                type="date"
                                                className="form-control"/>
                                            {errors.dateOfBirth && touched.dateOfBirth &&
                                                <div style={{color: 'red'}}>{errors.dateOfBirth}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Country</label>
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
                                            <label className="form-label d-flex justify-content-center">Email</label>
                                            <Field
                                                name="email"
                                                type="email"
                                                className="form-control"/>
                                            {errors.email && touched.email &&
                                                <div style={{color: 'red'}}>{errors.email}</div>}
                                        </div>

                                        <div className="col-xl-12 text-center">
                                            <button
                                                type="submit"
                                                className="btn btn-outline-primary w-50"
                                                disabled={isSubmitting}>
                                                Register
                                            </button>

                                        </div>
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
