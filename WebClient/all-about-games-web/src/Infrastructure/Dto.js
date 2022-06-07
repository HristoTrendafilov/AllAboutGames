import React from 'react';

export const RegisterUserRequest = {
    messageType: 'RegisterUserRequest',
    messageJson: {
        userDTO: {
            username: '',
            password: '',
            dateOfBirth: '',
            countryID: 0,
            email: ''
        }
    }
}
