import React from 'react';
import { Card, Row, Col, Form, Button } from "react-bootstrap";

function RegistrationCard() {
    return (
        <Card>
            <Card.Header>
                Registration
            </Card.Header>
            <Card.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="username" placeholder="Username" />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" placeholder="Email" />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Email" />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Repeat Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" />
                    </Form.Group>
                    <Form.Group>
                        <Button variant="dark" type="Repeat password">
                            Sign up
                        </Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

function Register() {
    return (
        <Row>
            <Col>
                <Row>
                    <Col>
                        <RegistrationCard />
                    </Col>
                </Row>
            </Col>
            <Col>
            </Col>
        </Row>
    );
}

export default Register;