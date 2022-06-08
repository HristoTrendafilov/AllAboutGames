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

    await axios.post('http://localhost:6002/api/gateway', gatewayRequest)
        .then(resp => {
            gatewayResponse.model = resp.data.JsonValue;

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