import React from 'react';
import {Route, Routes, BrowserRouter} from "react-router-dom";
import {RegisterUser} from "../ApplicationUser/Register";
import {Header} from "./Header";
import {LoginUser} from "../ApplicationUser/Login";

export class RouteTable extends React.PureComponent {
    render() {
        return (
            <BrowserRouter>
                <Header/>
                <Routes>
                    <Route path="/user/register" element={<RegisterUser/>}/>
                    <Route path="/user/login" element={<LoginUser/>}/>
                    <Route path="/" element={<RegisterUser/>}/>
                </Routes>
            </BrowserRouter>
        )
    }
}
