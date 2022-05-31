import * as Yup from "yup";

export const RegisterUserValidationSchema = Yup.object().shape({
    username: Yup.string()
        .min(2, 'Too Short!')
        .max(50, 'Too Long!')
        .required('username is required'),
    password: Yup.string().required('password is required'),
    dateOfBirth: Yup.date()
        .required('birth date is required'),
    countryID: Yup.number()
        .min(1)
        .required('country is required.')
});
