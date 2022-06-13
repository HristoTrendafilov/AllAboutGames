import {Form, Formik} from 'formik';
import React from 'react';
import * as Validations from '../Infrastructure/ValidationModels';
import {SendRequest} from '../Infrastructure/Server';
import {RegisterUserRequest} from '../Infrastructure/Dto'
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {DateField, SelectField, TextField} from "../Infrastructure/CutomFormikFields";
import {notify} from "../Infrastructure/Notify";

export class RegisterUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            stateErrors: [],
            countries: []
        }
    }

    componentDidMount = async () => {
        const response = await SendRequest('GetAllCountriesRequest', {});
        if (response.isFailed) {
            this.setState({stateErrors: response.errors});
            return;
        }

        this.setState({countries: response.model.Countries})
    }

    handleSubmit = async (data) => {
        const request = RegisterUserRequest;
        request.UserDTO = {...data};

        const response = await SendRequest('RegisterUserRequest', request);
        if (response.isFailed) {
            this.setState({stateErrors: response.errors});
            return;
        }

        notify('success', 'Successfully registered.', false)
        window.location.href = '/user/login'
    }

    redirect = () => {

        window.location.href = '/user/login';
        notify('success', 'Successfully registered.', false);
    }

    render() {
        const model = RegisterUserRequest.UserDTO;
        const {stateErrors, countries} = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card border-warning border-3" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body pb-0">

                        <Formik
                            initialValues={{...model}}
                            onSubmit={async (values) => {
                                await this.handleSubmit(values)
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
                                            options={countries}
                                        />

                                        <div className="col-xl-12 text-center mb-3">
                                            <button
                                                type="submit"
                                                className="btn btn-outline-primary w-50"
                                                disabled={isSubmitting}>
                                                Register
                                            </button>
                                        </div>

                                    <div className="col-xl-12 text-center mb-3">
                                        <button
                                            type="button"
                                            className="btn btn-outline-primary w-50"
                                            disabled={isSubmitting}
                                        onClick={this.redirect}>
                                            XAXAaa
                                        </button>
                                    </div>

                                        {stateErrors.length > 0 && <ErrorMessages apiErrors={stateErrors}/>}

                                </Form>
                            )}
                        </Formik>

                    </div>
                </div>
            </div>
        );
    }
}
