import {Field, Form, Formik} from 'formik';
import React from 'react';
import {GatewayMessage, RegisterUserRequest, UserDTO} from "../Infrastructure/Dto";

interface State {
    errorMessages: string[];
    loading: boolean;
    model: UserDTO | undefined;
}

export class RegisterUser extends React.PureComponent {
    state: State = {
        errorMessages: [],
        loading: false,
        model: undefined
    }

    handleSubmit = (data: UserDTO) => {
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

        fetch('http://localhost:6002/api/gateway',{
            method: 'POST',
            headers:{'Content-type':'application/json'},
            body: JSON.stringify(gateWay)
        }).then(res=>{
            if(res){
                this.setState({message:'New Employee is Created Successfully'});
            }
        });
    }

    render() {
        const{model}=this.state;

        return (
            <div className='d-flex justify-content-center'>
                <div className="card" style={{width: 600}}>
                    <h5 className="card-header">Registration</h5>
                    <div className="card-body">

                        <Formik
                            initialValues={{ ...model! }}
                            onSubmit={async (values: UserDTO) => {this.handleSubmit(values)}}>
                            {({isSubmitting}) => (
                                <Form>
                                    <div className="row">
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label justify-content-center d-flex">Username</label>
                                            <Field name="username" className="form-control"/>
                                        </div>
                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Password</label>
                                            <Field name="password" type="password" className="form-control"/>
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Birth date</label>
                                            <Field name="dateOfBirth" type="date" className="form-control"/>
                                        </div>

                                        <div className="mb-3 col-xl-6">
                                            <label className="form-label d-flex justify-content-center">Country</label>
                                            <Field as='select' name='countryID' className="form-select" aria-label="Default select example">
                                                <option selected>Open this select menu</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </Field>
                                        </div>

                                        <div className="col-xl-12 text-center">
                                            <button type="submit" className="btn btn-outline-primary w-50">Register</button>
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