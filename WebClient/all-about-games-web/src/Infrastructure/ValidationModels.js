import * as Yup from "yup";

export const RegisterUserValidationSchema = Yup.object().shape({
    username: Yup.string()
        .required('username is required'),
    dateOfBirth: Yup.date()
        .required('birth date is required'),
    countryID: Yup.number()
        .min(1, 'country is required.')
        .required('country is required.'),
    email: Yup.string()
        .required('email is required.')
});
