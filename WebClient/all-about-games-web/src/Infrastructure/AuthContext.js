import {createContext, useContext} from 'react';

import useLocalStorage from '../Infrastructure/useLocalStorage';

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [token, setToken] = useLocalStorage('token', '');

    const login = (authData) => {
        setToken(authData);
    }

    const logout = () => {
        setToken('');
    };

    return (
        <AuthContext.Provider value={{ token, login, logout, isAuthenticated: !!token }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuthContext = () => {
    return useContext(AuthContext);
}
