import React from 'react';
import {Route, Routes} from "react-router-dom";
import {CustomRoutes} from "./CustomRoutes";

export function RenderRouteTable(){
    return(
        <Routes>
            {CustomRoutes.map((x, i) => {
                return(
                    <Route key={i} path={x.path} element={x.element}/>
                )
            })}
        </Routes>
    )
}
