import React from 'react';
import {Route, Routes, BrowserRouter} from "react-router-dom";
import {RegisterUser} from "../ApplicationUser/Register";
import {Header} from "./Header";
import {LoginUser} from "../ApplicationUser/Login";
import {ToastContainer} from "react-toastify";

export class RouteTable extends React.PureComponent {
    render() {
        return (
            <>
                <ToastContainer autoClose={5000}/>
            <BrowserRouter>
                <Header/>
                <Routes>
                    <Route path="/user/register" element={<RegisterUser/>}/>
                    <Route path="/user/login" element={<LoginUser/>}/>
                    <Route path="/" element={<RegisterUser/>}/>
                </Routes>
            </BrowserRouter>

            </>
        )
    }
}
