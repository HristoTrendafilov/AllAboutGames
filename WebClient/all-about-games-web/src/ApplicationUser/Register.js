import {Field, Form, Formik} from 'formik';
import React from 'react';
import axios from "axios";
import * as Validations from '../Infrastructure/ValidationModels';

export class RegisterUser extends React.PureComponent {

    handleSubmit = async (data) => {
        console.log(data);

        const object = {

        }

        const objectStr = JSON.stringify(object);

        const gateWay = {
            messageType: 'RegisterUserRequest',
            messageJson: objectStrss
        }

        const toBeSend = JSON.stringify(gateWay);
        console.log(toBeSend);

        const response = await axios.post('http://localhost:6002/api/gateway', toBeSend);

    }

    render() {
        const model = {
            username: '',
            password: '',
            dateOfBirth: '',
            countryID: 0,
            email: '',
        }

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body">

                        <Formik
                            initialValues={{ ...model }}
                            onSubmit={async (values) => {await this.handleSubmit(values)}}
                            validationSchema={Validations.RegisterUserValidationSchema}
                        >
                            {({isSubmitting, errors, touched}) => (
                                <Form>

                                    <div className="row">
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex">Username</label>
                                            <Field
                                                name="username"
                                                type='input'
                                                className="form-control"/>
                                            {errors.username && touched.username && <div style={{color:'red'}}>{errors.username}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Password</label>
                                            <Field
                                                name="password"
                                                type="password"
                                                className="form-control"/>
                                            {errors.password && touched.password && <div style={{color:'red'}}>{errors.password}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Date of birth</label>
                                            <Field
                                                name="dateOfBirth"
                                                type="date"
                                                className="form-control"/>
                                            {errors.dateOfBirth && touched.dateOfBirth && <div style={{color:'red'}}>{errors.dateOfBirth}</div>}
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Country</label>
                                            <Field as='select' name='countryID' className="form-select">
                                                <option value="0">Select country</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </Field>
                                            {errors.countryID && touched.countryID && <div style={{color:'red'}}>{errors.countryID}</div>}
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
