import React from 'react';
import {RegisterUser} from "../ApplicationUser/Register";
import {LoginUser} from "../ApplicationUser/Login";
import {Home} from "../Home/Home";
import {AdminPanel} from "../ApplicationUser/Admin/AdminPanel";

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
    },
    {
        path: '/user/admin-panel',
        element: <AdminPanel/>
    }
]
