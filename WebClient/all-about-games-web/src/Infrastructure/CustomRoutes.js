import React from 'react';
import {RegisterUser} from "../ApplicationUser/Register";
import {LoginUser} from "../ApplicationUser/Login";
import {Home} from "../Home/Home";

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
        element: <Home/>
    }
]
