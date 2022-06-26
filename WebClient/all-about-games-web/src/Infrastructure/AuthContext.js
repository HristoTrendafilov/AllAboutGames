import {createContext, useContext, useState} from 'react';
import useLocalStorage from '../Infrastructure/useLocalStorage';
import {UserDTO} from "./Dto";

export const AuthContext = createContext(null);

export const AuthProvider = ({children}) => {
    const [user, setUser] = useLocalStorage('user', UserDTO);

    const login = (authData) => {
        authData.isAdministrator = authData.roles.some(e => e.name === "Administrator")
        setUser(authData);
    }

    const logout = () => {
        setUser(UserDTO);
    };

    return (
        <AuthContext.Provider value={{
            user,
            login,
            logout,
            isAuthenticated: user.userID > 0,
        }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuthContext = () => {
    return useContext(AuthContext);
}
