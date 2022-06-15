import React from 'react';
import axios from "axios";
import data from "bootstrap/js/src/dom/data";


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

    const token = localStorage.getItem('token');

    await axios.post('http://localhost:6002/api/gateway', gatewayRequest, {
        headers:{
            "Content-Type": "application/json",
            "Authorization":`Bearer ${token}`
        }
    })
        .then(resp => {
            gatewayResponse.model = JSON.parse(resp.data.JsonValue);

            resp.data.Details.map(x => {
                if (x.Type === 3) {
                    gatewayResponse.isFailed = true;
                    x.Message.split('\n').map(y => {
                        gatewayResponse.errors.push(y);
                    });
                }
            });
        })
        .catch(err => {
            gatewayResponse.errors.push(err.message);
            gatewayResponse.isFailed = true;
        });

    return gatewayResponse;
}
