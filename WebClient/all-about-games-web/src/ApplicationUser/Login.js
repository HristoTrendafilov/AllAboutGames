import React, {useEffect, useState} from "react";
import {Form, Formik} from "formik";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {SendRequest} from "../Infrastructure/Server";
import {notify} from "../Infrastructure/Notify";
import {useAuthContext} from '../Infrastructure/AuthContext';
// noinspection ES6CheckImport
import {useNavigate} from "react-router-dom";
import {LoadingSpinner} from "../Infrastructure/LoadingSpinner";
import * as Yup from "yup";

const initialValues = {
    username: '',
    password: '',
}

const ValidationSchema = Yup.object().shape({
    username: Yup.string()
        .required('username is required'),
    password: Yup.string()
        .required('password is required')
});

export function LoginUser() {

    const [state, setState] = useState({isLoading: false, stateErrors: []});
    const {login} = useAuthContext();
    const navigate = useNavigate();

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

        const {userDTO} = response.model;
        login(userDTO);
        navigate('/')
    }

    return (
        <div className='d-flex justify-content-center mt-4'>
            <div className="card border-info border-3 bg-transparent" style={{width: 600}}>
                <h4 className="card-header text-warning border-3 border-info">Login</h4>
                <div className="card-body pb-0">

                    <Formik
                        initialValues={{...initialValues}}
                        onSubmit={async (values) => {
                            await LoginUser(values)
                        }}
                        validationSchema={ValidationSchema}
                    >
                        {({isSubmitting}) => (
                            <Form className="row">

                                <div className="mb-2 col-xl-12">
                                    <TextField
                                        label="Username"
                                        name="username"
                                    />
                                </div>

                                <div className="mb-2 col-xl-12">
                                    <TextField
                                        label="Password"
                                        name="password"
                                        type="password"
                                    />
                                </div>

                                <div className="col-xl-12 text-center mb-3">
                                    <button
                                        type="submit"
                                        className="btn btn-outline-warning w-50"
                                        disabled={isSubmitting}>
                                        {state.isLoading ? <LoadingSpinner/> : 'Login'}
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
