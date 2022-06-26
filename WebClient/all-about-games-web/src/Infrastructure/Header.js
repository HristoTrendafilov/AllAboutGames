import React from 'react';
import {Container, Dropdown, Nav, Navbar} from "react-bootstrap";
import {useAuthContext} from './AuthContext';
// noinspection ES6CheckImport
import {Link, useNavigate} from "react-router-dom";

export function Header() {
    const {isAuthenticated, logout, user} = useAuthContext();
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
                            <Dropdown>
                                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                                    {user.username}
                                </Dropdown.Toggle>

                                <Dropdown.Menu variant="dark">
                                    <Dropdown.Item href="/user/profile/:id">Profile</Dropdown.Item>
                                    {user.isAdministrator &&
                                        <Dropdown.Item href="/user/admin/add-utilities">Add utilities</Dropdown.Item>
                                    }
                                    <Dropdown.Divider />
                                    <Dropdown.Item onClick={ () =>{
                                        logout();
                                        navigate('/');
                                    }}>Logout</Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                        </>
                    }
                </Nav>
            </Container>
        </Navbar>
    )
}
