import React, {useState} from 'react';
import {Card} from "react-bootstrap";
import {Form, Formik} from "formik";
import {TextField} from "../Infrastructure/CutomFormikFields";
import {LoadingSpinner} from "../Infrastructure/LoadingSpinner";
import {ErrorMessages} from "../Infrastructure/ErrorMessages";
import {SendRequest} from "../Infrastructure/Server";
import {notify} from "../Infrastructure/Notify";
import * as Yup from "yup";

const initialValues = {
    name: '',
}

const ValidationSchema = Yup.object().shape({
    name: Yup.string()
        .min(2, 'category name should have at least 2 characters')
        .max(100, 'category name should have 100 characters max')
        .required('category is required'),
});

export function GenreForm(){

    const [state, setState] = useState({isLoading: false, stateErrors: []});

    async function AddGameGenre(values) {
        setState({...state, isLoading: true})

        const request = { genreDTO: values };
        const response = await SendRequest('SaveGenreRequest', request);
        if (response.isFailed) {
            setState({...state, isLoading: false, stateErrors: response.errors});
            return;
        }

        setState({...state, isLoading: false, stateErrors: []})
        notify('success', `Successfully added game genre: ${values.name}`);
    }

    return(
        <Card className="border-info border-3 bg-dark">
            <Card.Header className="text-warning border-3 border-info">Add game genre</Card.Header>
            <Card.Body>
                <Formik
                    initialValues={{...initialValues}}
                    onSubmit={async (values) => {
                        await AddGameGenre(values)
                    }}
                    validationSchema={ValidationSchema}
                >
                    {({isSubmitting}) => (
                        <Form className="row">

                            <div className="mb-2 col-xl-12">
                                <TextField
                                    label="Name"
                                    name="name"
                                />
                            </div>

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
