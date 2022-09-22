import {toast} from 'react-toastify';
import React from 'react';

export function NotifySuccess(message, autoClose){
    return toast.success(<div style={{whiteSpace: "pre-wrap"}}>{message}</div>, {autoClose});
}

export function NotifyInfo(message, autoClose){
    return toast.info(<div style={{whiteSpace: "pre-wrap"}}>{message}</div>, {autoClose});
}

export function NotifyWarning(message, autoClose){
    return toast.success(<div style={{whiteSpace: "pre-wrap"}}>{message}</div>, {autoClose});
}

export function NotifyError(message, autoClose){
    return toast.error(<div style={{whiteSpace: "pre-wrap"}}>{message}</div>, {autoClose});
}