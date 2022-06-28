import React from 'react';

export const CountryDTO = {
    countryID: 0,
    name: '',
    iso: '',
    iso3: ''
}

export const UserDTO = {
    userID: 0,
    username: '',
    password: '',
    repeatPassword: '',
    dateOfBirth: '',
    countryID: 0,
    email: '',
    profilePicture: '',
    createdOn: '',
    country: CountryDTO,
    ratings: [],
    reviews: [],
    forumPosts: [],
    forumComments: [],
    feedbacks: [],
    userRoles: [],
    jwt: '',
    isAdministrator: false
}

export const RegisterUserRequest = {
    userDTO: {
        username: '',
        password: '',
        repeatPassword: '',
        dateOfBirth: '',
        countryID: 0,
        email: '',
        countries:[]
    }
}

export const LoginUserRequest = {
    username: '',
    password: '',
}

export const GetUserRequest = {
    userID: 0
}

export const SaveGenreRequest ={
    genreDTO:{
        name: ''
    }
}

export const SaveCountryRequest = {
    countryDTO: CountryDTO
}

