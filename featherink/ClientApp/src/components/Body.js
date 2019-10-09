import Container from "react-bootstrap/Container";
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';
import { Home } from './Home';
import { FetchData } from './FetchData';
import Login from './Login';
import Signup from './Signup';
import { Register } from './Register';

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/login' component={Login} />
            <Route path='/signup' component={Signup} />
            <Route path='/register' component={Register} />
        </Container>
    );
}

export default Body;