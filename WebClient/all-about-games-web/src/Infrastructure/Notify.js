import {toast} from 'react-toastify';
import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faExclamation, faInfoCircle} from '@fortawesome/free-solid-svg-icons';

export const notify = (type, message, autoClose) => {
    switch (type) {
        case 'warning':
            return toast.warn(<div><span className="mr-2"><FontAwesomeIcon icon={faExclamation} size="lg"/></span>{message}
            </div>, {autoClose, position: 'top-right'});
        case 'error':
            return toast.error(<div>{message}</div>, {autoClose, position: 'top-right'});
        case 'success':
            return toast.success(<div>{message}</div>, {autoClose, position: 'top-right', theme: "colored"});
        case 'info':
            return toast.info(<div><span className="mr-2"><FontAwesomeIcon icon={faInfoCircle} size="lg"/></span>{message}
            </div>, {autoClose, position: 'top-right'});
        default:
            return toast(message);
    }
};
