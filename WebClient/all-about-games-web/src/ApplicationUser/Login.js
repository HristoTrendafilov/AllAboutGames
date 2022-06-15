import React, {useEffect, useState} from "react";
import {Form, Formik} from "formik";
import * as Validations from "../Infrastructure/ValidationModels";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {LoginUserRequest, RegisterUserRequest} from "../Infrastructure/Dto";
import {SendRequest} from "../Infrastructure/Server";
import {notify} from "../Infrastructure/Notify";
import { useAuthContext } from '../Infrastructure/AuthContext';

export function LoginUser() {

    const [state, setState] = useState({model: RegisterUserRequest,isLoading: false, stateErrors: []});
    const { login, token } = useAuthContext();

    useEffect(() => {
        const params = new URLSearchParams(window.location.search);
        const hasRegistered = params.get('hasRegistered');
        if (hasRegistered) {
            notify('success', "Registration successful.\nLog into you\'r account");
        }

    }, [])

    LoginUser = async (data) => {
        setState({...state, isLoading: true})

        const response = await SendRequest('LoginUserRequest', data);
        if (response.isFailed) {
            setState({...state, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false})
        login(response.model.Jwt);
        console.log(token);

        // localStorage.setItem('token', response.model.Jwt);
        // window.location.href = '/'
    }

    return (
        <div className='d-flex justify-content-center mt-4'>
            <div className="card border-info border-3 bg-transparent" style={{width: 600}}>
                <h4 className="card-header text-warning border-3 border-info">Login</h4>
                <div className="card-body pb-0">

                    <Formik
                        initialValues={{...state.model}}
                        onSubmit={async (values) => {
                            await LoginUser(values)
                        }}
                        validationSchema={Validations.LoginUserValidationSchema}
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
                                        className="btn btn-outline-warning w-50"
                                        disabled={isSubmitting}>
                                        Login
                                    </button>
                                </div>

                                {state.stateErrors.length > 0 && <ErrorMessages apiErrors={state.stateErrors}/>}

                            </Form>
                        )}
                    </Formik>

                </div>
            </div>
        </div>
    )
}
