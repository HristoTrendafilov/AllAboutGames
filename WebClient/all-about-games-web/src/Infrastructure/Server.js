import React from 'react';
import axios from "axios";


export const SendRequest = async (requestName, data) => {

    const messageJson = {
        item: {
            ...data
        }
    }

    const gateWay = {
        messageType: requestName,
        messageJson: JSON.stringify(messageJson)
    }

    const toBeSend = JSON.stringify(gateWay);

    const response = await axios.post('http://localhost:6002/api/gateway', toBeSend)
        .then(resp => console.log(JSON.stringify(resp)))
        .catch(err => console.log(err));
}