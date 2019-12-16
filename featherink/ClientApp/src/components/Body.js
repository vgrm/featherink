import Container from "react-bootstrap/Container";
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';
import { Home } from './Home';
import { FetchData } from './FetchData';
import Login from './Login';
import Signup from './Signup';
import { Register } from './Register';
import Designers from './Designers';
import Designer from './Designer';

import Tasks from './Tasks';
import TaskNew from './TaskNew';

import ArtUpload from './ArtUpload';

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/login' component={Login} />
            <Route path='/signup' component={Signup} />
            <Route path='/register' component={Register} />
            <Route path='/designers' component={Designers} />
            <Route path='/designer/:designerId([0-9]+)' component={Designer} />
            <Route path='/tasks' component={Tasks} />
            <Route path='/tasknew' component={TaskNew} />
            <Route path='/artupload' component={ArtUpload} />
        </Container>
    );
}

export default Body;