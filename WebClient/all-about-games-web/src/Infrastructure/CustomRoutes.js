import React from 'react';
import {RegisterUser} from "../ApplicationUser/Register";
import {LoginUser} from "../ApplicationUser/Login";

export const CustomRoutes = [
    {
        path: '/user/register',
        element: <RegisterUser/>
    },
    {
        path: '/user/login',
        element: <LoginUser/>
    },
    {
        path: '/',
        element: <RegisterUser/>
    },
]
