import React from 'react';
import PropTypes from "prop-types";
import { Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
//import { Card, Row, Col, Form, Button } from "react-bootstrap";

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
import CreateIcon from '@material-ui/icons/Create';


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

function RegisterTask(props) {
    RegisterTask.propTypes = {
        name: PropTypes.string,
        description: PropTypes.string,
        onInputChange: PropTypes.func,
        onTasktSubmit: PropTypes.func
    }
    const classes = useStyles();

    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <CreateIcon />
                </Avatar>
                <Typography component="h1" variant="h5">
                    Order
        </Typography>
                <form className={classes.form} noValidate onSubmit={props.onTasktSubmit}>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <CssTextField
                                autoComplete="name"
                                name="name"
                                variant="outlined"
                                required
                                fullWidth
                                id="name"
                                label="name"
                                autoFocus
                                onChange={props.onInputChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <CssTextField
                                variant="outlined"
                                required
                                fullWidth
                                id="description"
                                label="Description"
                                name="description"
                                autoComplete="description"
                                onChange={props.onInputChange}
                            />
                        </Grid>
                    </Grid>
                    <ColorButton
                        type="submit"
                        fullWidth
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                    >
                        Order
          </ColorButton>
                </form>
            </div>
        </Container>
    );
}

class TaskNew extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            name: "",
            description: "",
            userId: 7,
            designerId: 7
        };
    }


    handleCloseDelete = async (id) => {

        fetch('api/task/' + id, { method: 'delete' })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        tasks: this.state.tasks.filter(x => x.id != result.id)
                    });
                })
    };


    onInputChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    onTasktSubmit = async (e) => {
        e.preventDefault();

        fetch(`api/task/`,
            {
                method: "POST",
                body: JSON.stringify({
                    name: this.state.name,
                    description: this.state.description,
                    userId: this.state.userId,
                    designerId: this.state.description
                }),
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            });
    }

    render() {
        return (
            <div>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <RegisterTask
                                    onTasktSubmit={this.onTasktSubmit}
                                    onInputChange={this.onInputChange}
                                />
                            </Col>
                        </Row>
                    </Col>

                </Row>
            </div>
        );
    }
}

export default TaskNew;