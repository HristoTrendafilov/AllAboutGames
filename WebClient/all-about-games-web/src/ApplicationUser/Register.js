import {Field, Form, Formik} from 'formik';
import React from 'react';
import * as Validations from '../Infrastructure/ValidationModels';
import {SendRequest} from '../Infrastructure/Server';
import {RegisterUserRequest} from '../Infrastructure/Dto'
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {CheckboxField, DateField, SelectField, TextField} from "../Infrastructure/CutomFormikFields";

export class RegisterUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            isLoading: false,
            stateErrors: [],
            countries:[]
        }
    }

    componentDidMount = async () => {
        const response = await SendRequest('GetAllCountriesRequest', {});
        if (response.isFailed) {
            this.setState({stateErrors: response.errors});
            return;
        }

        console.log(response.model.Countries);
        this.setState({countries: response.model})
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
        const {stateErrors, countries} = this.state;

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

                                        <TextField
                                            customClassName="mb-3 col-xl-12"
                                            label="Username"
                                            name="username"
                                            type="text"
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
                                            type="date"
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
