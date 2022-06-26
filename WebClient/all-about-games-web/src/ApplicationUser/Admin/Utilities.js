import React, {useState} from 'react';
import {Card} from "react-bootstrap";
import * as Validations from "../../Infrastructure/ValidationModels";
import {Form, Formik} from "formik";
import {TextField} from "../../Infrastructure/CutomFormikFields";
import {ErrorMessages} from "../../Infrastructure/ErrorMessages";
import {notify} from "../../Infrastructure/Notify";
import {AddGameGenreValidationSchema} from "../../Infrastructure/ValidationModels";
import {SendRequest} from "../../Infrastructure/Server";
import {LoadingSpinner} from "../../Infrastructure/LoadingSpinner";
import {RegisterUserRequest, SaveGenreRequest} from "../../Infrastructure/Dto";

export function Utilities() {

    const [state, setState] = useState({isLoading: false, stateErrors: []});

    async function AddGameCategory(values) {
        setState({...state, isLoading: true})

        const request = SaveGenreRequest;
        request.genreDTO = {...values};

        const response = await SendRequest('SaveGenreRequest', request);
        if (response.isFailed) {
            setState({...state, isLoading:false, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false, stateErrors: []})
        notify('success', `Successfully added game category: ${values.name}`);
    }

    return (
        <>
            <div className="row mt-4">
                <div className="col-xl-3">
                    <Card className="border-info border-3 bg-dark">
                        <Card.Header className="text-warning border-3 border-info">Game genre</Card.Header>
                        <Card.Body>
                            <Formik
                                initialValues={{name: ''}}
                                onSubmit={async (values) => {
                                    await AddGameCategory(values)
                                }}
                                validationSchema={Validations.AddGameGenreValidationSchema}
                            >
                                {({isSubmitting}) => (
                                    <Form className="row">

                                        <TextField
                                            customClassName="mb-3 col-xl-12"
                                            label="Name"
                                            name="name"
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
                </div>
            </div>
        </>
    )
}