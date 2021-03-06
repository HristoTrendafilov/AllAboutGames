import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-toastify/dist/ReactToastify.css';
import {BrowserRouter} from "react-router-dom";
import {Header} from "./Infrastructure/Header";
import {ToastContainer} from "react-toastify";
import {AuthProvider} from "./Infrastructure/AuthContext";
import {RenderRouteTable} from "./Infrastructure/RenderRouteTable";
import 'font-awesome/css/font-awesome.min.css';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <AuthProvider>
                <ToastContainer autoClose={5000} theme="colored" position={"bottom-right"}/>
                <Header/>
                <RenderRouteTable/>
            </AuthProvider>
        </BrowserRouter>
    </React.StrictMode>
);
