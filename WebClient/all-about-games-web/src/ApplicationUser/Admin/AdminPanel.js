import React from 'react';
import {CountryForm} from "../../Country/CountryForm";
import {GenreForm} from "../../Genre/GenreForm";
import {AddUserRoles} from "./AddUserRoles";
import {DeleteRolesFromUserForm} from "./DeleteUserRoles";

export function AdminPanel() {

    return (
        <div className="row mt-4">
            <div className="col-lg-4 mb-2">
                <AddUserRoles/>
            </div>
            <div className="col-lg-4 mb-2">
                <DeleteRolesFromUserForm/>
            </div>
            <div className="col-lg-4"></div>
            <div className="col-lg-2 mb-2">
                <GenreForm/>
            </div>
            <div className="col-lg-3 mb-2">
                <CountryForm/>
            </div>
            <div className="col-lg-7">
            </div>
        </div>
    )
}
