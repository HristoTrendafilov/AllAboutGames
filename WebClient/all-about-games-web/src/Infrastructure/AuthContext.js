import {createContext, useContext} from 'react';
import useLocalStorage from '../Infrastructure/useLocalStorage';

export const AuthContext = createContext(null);

const initialValue = {
    username: '',
    password: '',
    dateOfBirth: '',
    email: '',
    profilePicture: '',
    createdOn: '',
    jwt: '',
    country: {},
    ratings: [],
    reviews: [],
    forumPosts: [],
    forumComments: [],
    feedBacks: [],
    roles: []
}

export const AuthProvider = ({children}) => {
    const [user, setUser] = useLocalStorage('user', initialValue);

    const login = (authData) => {
        authData.isAdministrator = authData.roles.some(e => e.name === "Administrator")
        setUser(authData);
    }

    const logout = () => {
        setUser(initialValue);
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
