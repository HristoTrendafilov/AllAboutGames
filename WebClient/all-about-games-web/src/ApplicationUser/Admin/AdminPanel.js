import React from 'react';
import {CountryForm} from "../../Country/CountryForm";
import {GenreForm} from "../../Genre/GenreForm";

export function AdminPanel() {

    return (
        <div className="row mt-4">
            <div className="col-xl-2 mb-2" style={{paddingRight: 0}}>
                <GenreForm/>
            </div>
            <div className="col-xl-3" style={{paddingRight: 0}}>
                <CountryForm/>
            </div>
        </div>
    )
}
