import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-toastify/dist/ReactToastify.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import {Header} from "./Infrastructure/Header";
import {RegisterUser} from "./ApplicationUser/Register";
import {LoginUser} from "./ApplicationUser/Login";
import {ToastContainer} from "react-toastify";
import {AuthProvider} from "./Infrastructure/AuthContext";


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <AuthProvider>
                <ToastContainer autoClose={5000} theme="colored" position={"bottom-right"}/>
                <Header/>
                <Routes>
                    <Route path="/user/register" element={<RegisterUser/>}/>
                    <Route path="/user/login" element={<LoginUser/>}/>
                    <Route path="/" element={<RegisterUser/>}/>
                </Routes>
            </AuthProvider>
        </BrowserRouter>
    </React.StrictMode>
);
