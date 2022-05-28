export interface RegisterUserRequest{
    item: UserDTO;
}

export interface UserDTO{
    username: string;
    password: string;
    dateOfBirth: Date;
    countryID: number;
}

export interface GatewayMessage {
    messageType: string;
    messageJson: string;
}