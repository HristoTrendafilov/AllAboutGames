import * as Yup from "yup";

export const RegisterUserValidationSchema = Yup.object().shape({
    username: Yup.string()
        .min(3, 'Username must be between 3 and 50 characters long.')
        .max(50, 'Username must be between 3 and 50 characters long.')
        .required('username is required'),
    password: Yup.string()
        .min(5, "Your password must be longer than 5 characters.")
        .required('Password is required'),
    repeatPassword: Yup.string()
        .required('Repeat the password.')
        .oneOf([Yup.ref('password'), null], 'Passwords do not match!'),
    dateOfBirth: Yup.date()
        .required('birth date is required'),
    countryID: Yup.number()
        .min(1, 'country is required.')
        .required('country is required.'),
    email: Yup.string()
        .required('email is required.')
});

export const LoginUserValidationSchema = Yup.object().shape({
   username: Yup.string()
       .required('username is required'),
   password: Yup.string()
       .required('password is required')
});

export const AddGameGenreValidationSchema = Yup.object().shape({
    name: Yup.string()
        .min(2, 'category name should have at least 2 characters')
        .required('category is required'),
});
