import React from 'react';
import axios from "axios";


export const SendRequest = async (data) => {

    const gateway = {
        messageType: data.messageType,
        messageJson: data.messageJson
    }

    const gatewayRequest = JSON.stringify(gateway);

    await axios.post('http://localhost:6002/api/gateway', gatewayRequest)
        .then(resp => {
            return JSON.stringify(resp.data)
        })
}
