import React, {useEffect, useState} from 'react';
import {Card} from "react-bootstrap";
import {Form, Formik} from "formik";
import {SelectField, TextField} from "../../Infrastructure/CutomFormikFields";
import {LoadingSpinner} from "../../Infrastructure/LoadingSpinner";
import {ErrorMessages} from "../../Infrastructure/ErrorMessages";
import {SendRequest} from "../../Infrastructure/Server";
import {notify} from "../../Infrastructure/Notify";

const initialValues = {
    userID: 0,
    roles: [],
}

export function AddRolesToUserForm() {

    const [state, setState] = useState({isLoading: false, stateErrors: [], users: [], roles: []});

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
        console.log(values);

        setState({...state, isLoading: true})

        const request = SaveGenreRequest;
        request.genreDTO = {...values};

        const response = await SendRequest('SaveGenreRequest', request);
        if (response.isFailed) {
            setState({...state, isLoading: false, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false, stateErrors: []})
        notify('success', `Successfully added roles to user`);
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
                >
                    {({isSubmitting}) => (
                        <Form className="row">

                            <SelectField
                                customClassName="mb-3 col-xl-6 offset-xl-3"
                                name='userID'
                                label='User'
                                placeholder='Select user'
                                options={state.users}
                            />

                            <SelectField
                                customClassName="mb-3 col-xl-12"
                                name='roles'
                                label='Roles'
                                isMulti={true}
                                placeholder='Select roles'
                                options={state.roles}
                            />

                            <div className="col-xl-12 text-center">
                                <button
                                    type="submit"
                                    className="btn btn-outline-warning w-50 mb-2"
                                    disabled={isSubmitting}>
                                    {state.isLoading ? <LoadingSpinner/> : 'Add'}
                                </button>

                            </div>

                            {state.stateErrors.length > 0 && <ErrorMessages apiErrors={state.stateErrors}/>}

                        </Form>
                    )}
                </Formik>
            </Card.Body>
        </Card>
    )
}
