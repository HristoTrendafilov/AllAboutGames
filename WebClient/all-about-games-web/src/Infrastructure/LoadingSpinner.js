import React from 'react';
import {faSpinner} from "@fortawesome/fontawesome-free-solid";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

export function LoadingSpinner() {
    return (
        <FontAwesomeIcon icon={faSpinner} spin size="lg"/>
    )
}