import * as Validations from './Validations'

export interface RegisterUserRequest{
    item: UserDTO;
}

export interface UserDTO{
    username: string;
    password: string;
    dateOfBirth: string;
    countryID: number;
}

export interface GatewayMessage {
    messageType: string;
    messageJson: string;
}

export const serverValidations = {
    UserDTO:{
        username: [Validations.required("The username is required")],
        password: [Validations.required("The password is required")],
        dateOfBirth: [Validations.required("Date of birth is required")],
        countryID: [Validations.required("Please select a country")],
    }
}