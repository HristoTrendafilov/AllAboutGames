import {createContext, useContext, useState} from 'react';

import useLocalStorage from '../Infrastructure/useLocalStorage';

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [token, setToken] = useLocalStorage('token', '');
    const [username, setUsername] = useState('');

    const login = (authData, username) => {
        setToken(authData);
        setUsername(username);
    }

    const logout = () => {
        setToken('');
        setUsername('');
    };

    return (
        <AuthContext.Provider value={{ token, login, logout, isAuthenticated: !!token, username }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuthContext = () => {
    return useContext(AuthContext);
}
