import React from 'react';

export const RegisterUserRequest = {
    UserDTO: {
        username: '',
        password: '',
        repeatPassword: '',
        dateOfBirth: '',
        countryID: 0,
        email: '',
    }
}

export const LoginUserRequest = {
    username: '',
    password: '',
}

export const GetUserRequest = {
    userID: 0
}
