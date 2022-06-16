import React from 'react';
import {Container, Nav, Navbar} from "react-bootstrap";
import {useAuthContext} from './AuthContext';
// noinspection ES6CheckImport
import {useNavigate} from "react-router-dom";

export function Header() {
    const {isAuthenticated, logout, username} = useAuthContext();
    const navigate = useNavigate();

    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="/">AllAboutGames</Navbar.Brand>
                <Nav>
                    {!isAuthenticated ?
                        <>
                            <Nav.Link href="/user/register">Register</Nav.Link>
                            <Nav.Link href="/user/login">Login</Nav.Link>
                        </>
                        :
                        <>
                            <Nav.Link href="/user/profile">{username}</Nav.Link>
                            <Nav.Link onClick={() => {
                                logout();
                                navigate('/');
                            }}>Logout
                            </Nav.Link>
                        </>
                    }
                </Nav>
            </Container>
        </Navbar>
    )
}
