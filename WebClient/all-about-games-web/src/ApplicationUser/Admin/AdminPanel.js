import React from 'react';
import {CountryForm} from "../../Country/CountryForm";
import {GenreForm} from "../../Genre/GenreForm";
import {AddRolesToUserForm} from "./AddRolesToUserForm";

export function AdminPanel() {

    return (
        <div className="row mt-4">
            <div className="col-lg-2 mb-2" style={{paddingRight: 0}}>
                <GenreForm/>
            </div>
            <div className="col-lg-3" style={{paddingRight: 0}}>
                <CountryForm/>
            </div>
            <div className="col-lg-7" style={{paddingRight: 0}}>
            </div>
            <div className="col-lg-5" style={{paddingRight: 0}}>
                <AddRolesToUserForm/>
            </div>
        </div>
    )
}
