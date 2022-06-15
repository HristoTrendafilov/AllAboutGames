import React from 'react';
import {Container, Nav, Navbar} from "react-bootstrap";
import {useAuthContext} from './AuthContext';

export function Header() {
    const {isAuthenticated} = useAuthContext();

    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="#home">AllAboutGames</Navbar.Brand>
                <Nav>
                    {!isAuthenticated ?
                        <>
                            <Nav.Link href="/user/register">Register</Nav.Link>
                            <Nav.Link href="/user/login">Login</Nav.Link>
                        </>
                        :
                        <Nav.Link href="/user/logout">Logout</Nav.Link>
                    }
                </Nav>
            </Container>
        </Navbar>
    )
}
