import React from "react";
import {Form, Formik} from "formik";
import * as Validations from "../Infrastructure/ValidationModels";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {LoginUserRequest, RegisterUserRequest} from "../Infrastructure/Dto";
import {SendRequest} from "../Infrastructure/Server";
import {notify} from "../Infrastructure/Notify";

export class LoginUser extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            isLoading: false,
            stateErrors: [],
        }
    }

    componentDidMount() {
        const params = new URLSearchParams(window.location.search);
        const hasRegistered = params.get('hasRegistered');
        if (hasRegistered){
            notify('success', "Registration successful.\nLog into you\'r account");
        }
    }

    LoginUser = async (data) => {
        this.setState({isLoading: true});

        const response = await SendRequest('LoginUserRequest', data);
        if (response.isFailed) {
            this.setState({stateErrors: response.errors});
            return;
        }

        this.setState({isLoading:false})
        window.location.href = '/'
    }

    render() {
        const model = LoginUserRequest;
        const {stateErrors} = this.state;

        return (
            <div className='d-flex justify-content-center mt-4'>
                <div className="card border-info border-3 bg-transparent" style={{width: 600}}>
                    <h4 className="card-header text-warning border-3 border-info">Login</h4>
                    <div className="card-body pb-0">

                        <Formik
                            initialValues={{...model}}
                            onSubmit={async (values) => {
                                await this.LoginUser(values)
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
