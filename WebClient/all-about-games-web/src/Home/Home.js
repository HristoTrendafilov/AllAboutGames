import React from 'react';
import {useAuthContext} from "../Infrastructure/AuthContext";

export function Home(){
    const {user} = useAuthContext();
    console.log(user);

    return(
        <div>Home</div>
    )
}