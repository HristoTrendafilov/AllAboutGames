import {toast} from 'react-toastify';
import React from 'react';

export const notify = (type, message, autoClose) => {
    switch (type) {
        case 'warning':
            return toast.warn(<div>{message}</div>, {autoClose, position: 'top-right'});
        case 'error':
            return toast.error(<div>{message}</div>, {autoClose});
        case 'success':
            return toast.success(<div style={{whiteSpace: "pre-wrap"}}>{message}</div>, {autoClose});
        case 'info':
            return toast.info(<div>{message}</div>, {autoClose});
        default:
            return toast(message);
    }
};
