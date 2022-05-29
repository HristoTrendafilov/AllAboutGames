import {Field, Form, Formik} from 'formik';
import React from 'react';
import {GatewayMessage, RegisterUserRequest, UserDTO, serverValidations} from "../Infrastructure/Dto";
import * as Yup from 'yup';
import axios from "axios";


interface State {
    errorMessages: string[];
    loading: boolean;
    model: UserDTO;
}

export class RegisterUser extends React.PureComponent {
    state: State = {
        errorMessages: [],
        loading: false,
        model: {
            username: '',
            password: '',
            dateOfBirth: '',
            countryID: 0,
        }
    }

    handleSubmit = async (data: UserDTO) => {
        console.log('in');
        const user: UserDTO = {
            username: data.username,
            password: data.password,
            dateOfBirth: data.dateOfBirth,
            countryID: data.countryID
        }

        const object: RegisterUserRequest = {
            item: user
        }

        const objectStr = JSON.stringify(object);

        const gateWay: GatewayMessage = {
            messageType: 'RegisterUserRequest',
            messageJson: objectStr
        }

        const toBeSend = JSON.stringify(gateWay);
        console.log(toBeSend);

        const response = await axios.post('http://localhost:6002/api/gateway', toBeSend);

    }

     DisplayingErrorMessagesSchema = Yup.object().shape({
        username: Yup.string()
            .min(2, 'Too Short!')
            .max(50, 'Too Long!')
            .required('username is required'),
        password: Yup.string().required('password is required'),
        dateOfBirth: Yup.date()
            .required('birth date is required'),
        countryID: Yup.number()
            .min(1)
            .required('country is required.')
    });

    render() {
        const { model } = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body">

                        <Formik
                            initialValues={{ ...model! }}
                            onSubmit={async (values: UserDTO) => {this.handleSubmit(values)}}
                            validationSchema={this.DisplayingErrorMessagesSchema}
                        >
                            {({isSubmitting, errors}) => (
                                <Form>
                                    <div className="row">
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex">Username</label>
                                            <Field
                                                name="username"
                                                type='input'
                                                className="form-control"/>
                                        </div>
                                        {errors.username && <div>{errors.username}</div>}
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Password</label>
                                            <Field
                                                name="password"
                                                type="password"
                                                className="form-control"/>
                                        </div>
                                        {errors.password && <div>{errors.password}</div>}
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Birth date</label>
                                            <Field
                                                name="dateOfBirth"
                                                type="date"
                                                className="form-control"/>
                                        </div>
                                        {errors.dateOfBirth && <div>{errors.dateOfBirth}</div>}
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Country</label>
                                            <Field as='select' name='countryID' className="form-select">
                                                <option value="0">Select country</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </Field>
                                        </div>
                                        {errors.countryID && <div>{errors.countryID}</div>}
                                        <div className="col-xl-12 text-center">
                                            <button
                                                type="submit"
                                                className="btn btn-outline-primary w-50"
                                                >
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