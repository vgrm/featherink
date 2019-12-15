import React, { Component } from 'react';
//import { Card, Row, Col, Form, Button } from "react-bootstrap";
//import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { withRouter } from "react-router";
import PropTypes from "prop-types";

import styled from 'styled-components'

//import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

import colors from "../Constants/colors";


const CssTextField = withStyles({
    root: {
        '& label.Mui-focused': {
            color: colors.secondaryColorLight,
        },
        '& .MuiInput-underline:after': {
            borderBottomColor: colors.primaryColorLight,
        },
        '& .MuiOutlinedInput-root': {
            '& fieldset': {
                borderColor: colors.secondaryColorLight,
            },
            '&:hover fieldset': {
                borderColor: colors.primaryColorDark,
            },
            '&.Mui-focused fieldset': {
                borderColor: colors.primaryColorLight,
            },
        },
    },
})(TextField);

const ColorButton = withStyles(theme => ({
    root: {
        color: colors.white,
        backgroundColor: colors.primaryColor,
        '&:hover': {
            backgroundColor: colors.primaryColorDark,
        },
    },
}))(Button);

function Copyright() {
    return (
        <Typography variant="body2" color={colors.primaryColor} align="center">
            {'Copyright © '}
            <Link color="inherit" href="https://material-ui.com/">
                FeatherInk
      </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const useStyles = makeStyles(theme => ({
    paper: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: colors.primaryColor,
        //    theme.palette.secondary.main,
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
}));

function mapDispatchToProps(dispatch, props) {
    return {
        onSignInSubmit: (e) => {
            e.preventDefault();
            dispatch({ type: "LOGIN_SUCCESS" });
            props.history.push("/");
        }
    };
}


export default function SignIn({ onSignInSubmit }) {

    SignIn.propTypes = {
        onSignInSubmit: PropTypes.func
    }

    const classes = useStyles();

    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="h5">
                    Sign in
        </Typography>
                <form className={classes.form} noValidate onSubmit={onSignInSubmit}>
                    <CssTextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        id="username"
                        label="Username"
                        name="username"
                        autoComplete="username"
                        autoFocus
                    />
                    <CssTextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        name="password"
                        label="Password"
                        type="password"
                        id="password"
                        autoComplete="current-password"
                    />
                    <FormControlLabel
                        control={<Checkbox value="remember" color="primary" />}
                        label="Remember me"
                    />
                    <ColorButton
                        type="submit"
                        fullWidth
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                    >
                        Sign In
          </ColorButton>
                    <Grid container>
                        <Grid item xs>
                            <Typography component="h1" variant="h5">
                                <Link href="#" variant="body2" color="inherit">
                                    Forgot password?
              </Link>
                            </Typography>


                        </Grid>
                        <Grid item>
                            <Typography component="h1" variant="h5">
                                <Link href="/signup" variant="body2" color="inherit">
                                    {"Don't have an account? Sign Up"}
                                </Link>
                            </Typography>

                        </Grid>
                    </Grid>
                </form>
            </div>
            <Box mt={8}>
                <Copyright />
            </Box>
        </Container>
    );
}

/*
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

*/