import React from 'react';
import axios from "axios";
import {useAuthContext} from "./AuthContext";
import {useNavigate} from "react-router-dom";

export const SendRequest = async (messageType, messageJson) => {
    const {logout} = useAuthContext();
    const navigate = useNavigate();

    const gatewayMessage = {
        MessageType: messageType,
        MessageJson: JSON.stringify(messageJson)
    }

    const gatewayRequest = JSON.stringify(gatewayMessage);

    const gatewayResponse = {
        responseType: '',
        model: {},
        errors: [],
        isFailed: false
    }

    const user = JSON.parse(localStorage.getItem('user') || '');

    await axios.post('http://localhost:6002/api/gateway', gatewayRequest, {
        headers:{
            "Content-Type": "application/json",
            "Authorization":`Jwt ${user.jwt}`
        }
    })
        .then(resp => {
            const {JsonValue, Details} = resp.data;
            gatewayResponse.model = JSON.parse(JsonValue);

            Details.map(x => {
                if (x.Type === 3) {
                    const {Message} = x;
                    Message.split('\n').map(y => {gatewayResponse.errors.push(y)});
                }
            });
        })
        .catch(err => {
            gatewayResponse.errors.push(err.message);
        });

    if(gatewayResponse.model.responseType === 'LogoutUserResponse'){
        logout();
        navigate('/');

        return;
    }

    gatewayResponse.isFailed = gatewayResponse.errors.length > 0;
    return gatewayResponse;
}
