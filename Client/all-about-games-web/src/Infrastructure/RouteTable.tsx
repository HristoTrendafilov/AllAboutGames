import React from 'react';
import {Route,Routes, BrowserRouter} from "react-router-dom";
import {RegisterUser} from "../ApplicationUser/Register";
import {Header} from "./Header";

export class RouteTable extends React.PureComponent{
    render(){
        return(
            <BrowserRouter>
                <Header/>
                <Routes>
                    <Route path="/user/register" element={<RegisterUser />} />
                    <Route path="/" element={<RegisterUser />} />
                </Routes>
            </BrowserRouter>
        )
    }
}