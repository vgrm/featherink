import React, { Component } from 'react';
import { Card, Row, Col, Form, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { withRouter } from "react-router";
import PropTypes from "prop-types";

import styled from 'styled-components'

function ForgotPasswordCard() {
    return (
        <Card>
            <Card.Header>
                Forgot your password?
            </Card.Header>
            <Card.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" placeholder="Email" />
                    </Form.Group>
                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Send a reminder
                        </Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

function LogInCard({ onLoginFormSubmit }) {
    LogInCard.propTypes = {
        onLoginFormSubmit: PropTypes.func
    }

    return (
        <Card>
            <Card.Header>
                Log in
            </Card.Header>
            <Card.Body>
                <Form onSubmit={onLoginFormSubmit}>
                    <Form.Group>
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="username" placeholder="Username" />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" />
                    </Form.Group>
                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Log in
                        </Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

function GoToRegisterPageCard() {
    return (
        <Card>
            <Card.Header>
                Haven&#39;t registered yet ?
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    <label>Use this link to sign up</label>
                </div>
                <div className="form-group">
                    <Link to="/registration">To sign up page</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

function mapDispatchToProps(dispatch, props) {
    return {
        onLoginFormSubmit: (e) => {
            e.preventDefault();
            dispatch({ type: "LOGIN_SUCCESS" });
            props.history.push("/");
        }
    };
}

function LogIn(props) {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <LogInCard {...props} />
                    </Col>
                </Row>
            </Col>

            <Col>
                <Row>
                    <Col>
                        <ForgotPasswordCard />
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <GoToRegisterPageCard />
                    </Col>
                </Row>
            </Col>

        </Row>
    );
}

export default withRouter(connect(() => { }, mapDispatchToProps)(LogIn));
