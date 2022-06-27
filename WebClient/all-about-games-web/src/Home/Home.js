import React from 'react';
import {useAuthContext} from "../Infrastructure/AuthContext";

export function Home(){
    const {user} = useAuthContext();

    return(
        <div>Home</div>
    )
}
