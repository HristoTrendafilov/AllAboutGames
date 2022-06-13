import React from "react";
import {Form, Formik} from "formik";
import * as Validations from "../Infrastructure/ValidationModels";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {LoginUserRequest} from "../Infrastructure/Dto";

export class LoginUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            isLoading: false,
            stateErrors: [],
            countries: []
        }
    }

    LoginUser(data){

    }

    render() {
        const model = LoginUserRequest;
        const {stateErrors} = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card border-warning border-3" style={{width: 500}}>
                    <h5 className="card-header">Login</h5>
                    <div className="card-body pb-0">

                        <Formik
                            initialValues={{...model}}
                            onSubmit={async (values) => {
                                await this.LoginUser(values)
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
                                        customClassName="mb-3 col-xl-12"
                                        label="Password"
                                        name="password"
                                        type="password"
                                    />

                                    <div className="col-xl-12 text-center mb-3">
                                        <button
                                            type="submit"
                                            className="btn btn-outline-success w-50"
                                            disabled={isSubmitting}>
                                            Login
                                        </button>
                                    </div>

                                    {stateErrors.length > 0 && <ErrorMessages apiErrors={stateErrors}/>}

                                </Form>
                            )}
                        </Formik>

                    </div>
                </div>
            </div>
        )
    }
}
