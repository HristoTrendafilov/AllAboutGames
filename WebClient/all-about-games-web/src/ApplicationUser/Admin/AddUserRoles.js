import React, {useEffect, useState} from 'react';
import {Card} from "react-bootstrap";
import {Form, Formik} from "formik";
import {SelectField, TextField} from "../../Infrastructure/CutomFormikFields";
import {LoadingSpinner} from "../../Infrastructure/LoadingSpinner";
import {ErrorMessages} from "../../Infrastructure/ErrorMessages";
import {SendRequest} from "../../Infrastructure/Server";
import {NotifySuccess} from "../../Infrastructure/Notify";
import * as Yup from "yup";

const initialValues = {
    userID: 0,
    roles: [],
}

const ValidationSchema = Yup.object().shape({
    userID: Yup.number()
        .min(1, 'user is required.')
        .required('user is required.'),
    roles: Yup.array()
        .min(1, 'roles are required')
        .required('roles are required')
});

export function AddUserRoles() {

    const [state, setState] = useState({
        isLoading: false,
        stateErrors: [],
        users: [],
        roles: [],
        hasCheckedUserRoles: false,
        userRoles: []
    });

    useEffect(() => {
        (async () => {
            const rolesResponse = await SendRequest('GetRolesRequest', {});
            if (rolesResponse.isFailed) {
                setState({...state, stateErrors: rolesResponse.errors});
                return;
            }

            const usersResponse = await SendRequest('GetUsersRequest', {});
            if (usersResponse.isFailed) {
                setState({...state, stateErrors: usersResponse.errors});
                return;
            }

            const {rolesDTO} = rolesResponse.model;
            const {usersDTO} = usersResponse.model;
            setState({...state, isLoading: false, roles: rolesDTO, users: usersDTO})
        })();
    }, [])

    async function AddRolesToUser(values) {
        setState({...state, isLoading: true})

        const request = {
            userID: values.userID,
            roles: values.roles
        };

        const response = await SendRequest('AddUserRolesRequest', request);
        if (response.isFailed) {
            setState({...state, isLoading: false, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false, stateErrors: []})
        NotifySuccess(`Successfully added roles to user`);
    }

    async function CheckUserRoles(userID) {

        const rolesResponse = await SendRequest('GetRolesRequest', {userID});
        if (rolesResponse.isFailed) {
            setState({...state, stateErrors: rolesResponse.errors});
            return;
        }

        const {rolesDTO} = rolesResponse.model;
        setState({...state, hasCheckedUserRoles: true, userRoles: rolesDTO})
    }

    return (
        <Card className="border-info border-3 bg-dark">
            <Card.Header className="text-warning border-3 border-info">Add roles to user</Card.Header>
            <Card.Body>
                <Formik
                    initialValues={{...initialValues}}
                    onSubmit={async (values) => {
                        await AddRolesToUser(values)
                    }}
                    validationSchema={ValidationSchema}
                >
                    {({isSubmitting, values, setFieldTouched}) => (
                        <Form className="row">

                            <div className="col-sm-5">
                                <SelectField
                                    name='userID'
                                    label='User'
                                    placeholder='Select user'
                                    options={state.users}
                                />
                            </div>

                            <div className="mb-3 col-sm-7">
                                <SelectField
                                    name='roles'
                                    label='Roles'
                                    isMulti={true}
                                    placeholder='Select roles'
                                    options={state.roles}
                                />
                            </div>

                            <div className="col-6">
                                <button
                                    type="button"
                                    className="btn btn-outline-info"
                                    onClick={async () =>{
                                        setFieldTouched('userID');
                                        if(values.userID !== 0){
                                            await CheckUserRoles(values.userID)
                                        }
                                    }}
                                    disabled={state.isLoading}>
                                    {state.isLoading ? <LoadingSpinner/> : 'Check user roles'}
                                </button>
                            </div>

                            <div className="col-6">
                                <button
                                    type="submit"
                                    className="btn btn-outline-warning w-100 mb-2"
                                    disabled={isSubmitting}>
                                    {state.isLoading ? <LoadingSpinner/> : 'Add'}
                                </button>
                            </div>

                            {state.hasCheckedUserRoles &&
                                <div className="col-sm-12 text-white mb-2">
                                    {state.userRoles.length ?
                                        `User roles: ${state.userRoles.map(x => x.name)}`
                                        :
                                        `The user doesn't have any roles`
                                    }
                                </div>
                            }

                            {state.stateErrors.length > 0 && <ErrorMessages apiErrors={state.stateErrors}/>}

                        </Form>
                    )}
                </Formik>
            </Card.Body>
        </Card>
    )
}
