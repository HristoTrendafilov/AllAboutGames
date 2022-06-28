import React, {useState} from 'react';
import {Card} from "react-bootstrap";
import {Form, Formik} from "formik";
import * as Validations from "../Infrastructure/ValidationModels";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {LoadingSpinner} from "../Infrastructure/LoadingSpinner";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {SaveCountryRequest} from "../Infrastructure/Dto";
import {SendRequest} from "../Infrastructure/Server";
import {notify} from "../Infrastructure/Notify";

export function CountryForm(){

    const [state, setState] = useState({isLoading: false, stateErrors: []});

    async function AddCountry(values) {
        setState({...state, isLoading: true})

        const request = SaveCountryRequest;
        request.countryDTO = {...values};

        const response = await SendRequest('SaveCountryRequest', request);
        if (response.isFailed) {
            setState({...state, isLoading: false, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false, stateErrors: []})
        notify('success', `Successfully added country: ${values.name}`);
    }

    return(
        <Card className="border-info border-3 bg-dark">
            <Card.Header className="text-warning border-3 border-info">Country</Card.Header>
            <Card.Body>
                <Formik
                    initialValues={{name: '', iso: ''}}
                    onSubmit={async (values) => {
                        await AddCountry(values)
                    }}
                    validationSchema={Validations.AddCountryValidationSchema}
                >
                    {({isSubmitting}) => (
                        <Form className="row">

                            <TextField
                                customClassName="mb-3 col-xl-8"
                                label="Name"
                                name="name"
                            />

                            <TextField
                                customClassName="mb-3 col-xl-4"
                                label="Short name"
                                name="iso"
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
