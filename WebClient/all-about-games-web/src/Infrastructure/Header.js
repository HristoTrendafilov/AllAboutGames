import React from 'react';
import {Container, Nav, Navbar} from "react-bootstrap";

export class Header extends React.PureComponent{
    render() {
        return(
            <Navbar bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand href="#home">AllAboutGames</Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link href="#home">Home</Nav.Link>
                    </Nav>
                    <Nav>
                        <Nav.Link href="/user/register">Register</Nav.Link>
                        <Nav.Link href="/user/login">Login</Nav.Link>
                    </Nav>
                </Container>
            </Navbar>
        )
    }
}
