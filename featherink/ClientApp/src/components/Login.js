import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <h1>Login</h1>

                <p>This is a simple example of a React component.</p>
                <p aria-live="polite">Current count:</p>

            </div>
        );
    }
}
