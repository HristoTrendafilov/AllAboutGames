import React from 'react';
import axios from "axios";

export const SendRequest = async (messageType, messageJson) => {
    const gatewayMessage = {
        MessageType: messageType,
        MessageJson: JSON.stringify(messageJson)
    }

    const gatewayRequest = JSON.stringify(gatewayMessage);

    const gatewayResponse = {
        model: {},
        errors: [],
        isFailed: false
    }

    let token = localStorage.getItem('token') || '';

    await axios.post('http://localhost:6002/api/gateway', gatewayRequest, {
        headers:{
            "Content-Type": "application/json",
            "Authorization":`Jwt ${token}`
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

    gatewayResponse.isFailed = gatewayResponse.errors.length > 0;
    return gatewayResponse;
}
